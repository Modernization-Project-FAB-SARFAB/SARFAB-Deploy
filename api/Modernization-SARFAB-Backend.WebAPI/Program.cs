using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Modernization_SARFAB_Backend.Infrastructure.Dependencies;
using Modernization_SARFAB_Backend.WebAPI.Middleware;
using Modernization_SARFAB_Backend.Infrastructure.Configuration;
using Serilog;
using Serilog.Events;
using System.Text;
using Microsoft.AspNetCore.RateLimiting;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .MinimumLevel.Override("System", LogEventLevel.Warning)
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File(
        path: "logs/log-.txt",
        rollingInterval: RollingInterval.Day,
        retainedFileCountLimit: 7,
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}",
        flushToDiskInterval: TimeSpan.FromSeconds(1)
    )
    .CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.WebHost.UseUrls("http://0.0.0.0:80");
    builder.Host.UseSerilog();

    builder.Services.AddInfrastructure(builder.Configuration);

    // Configuración de opciones
    builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
    builder.Services.PostConfigure<JwtOptions>(opts =>
    {
        opts.Key = Environment.GetEnvironmentVariable("JWT_KEY") ?? "";
    });

    builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
    builder.Services.PostConfigure<SmtpSettings>(opts =>
    {
        opts.Password = Environment.GetEnvironmentVariable("SMTP_PASSWORD") ?? "";
    });

    // Rate Limiting
    builder.Services.AddMemoryCache();
    builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
    builder.Services.AddInMemoryRateLimiting();
    builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

    var jwtOptions = new JwtOptions();
    builder.Configuration.GetSection("Jwt").Bind(jwtOptions);
    jwtOptions.Key = Environment.GetEnvironmentVariable("JWT_KEY") ?? "";

    if (string.IsNullOrEmpty(jwtOptions.Key))
        throw new InvalidOperationException("JWT_KEY no está definido.");

    var smtpPassword = Environment.GetEnvironmentVariable("SMTP_PASSWORD");
    if (string.IsNullOrEmpty(smtpPassword))
        throw new InvalidOperationException("SMTP_PASSWORD no está definido.");

    builder.Services.AddControllers()
        .ConfigureApiBehaviorOptions(options =>
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                var errors = context.ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value.Errors.First().ErrorMessage
                    );
                var result = new
                {
                    success = false,
                    message = "Error de validación",
                    errors = errors,
                    errorCode = "VALIDATION_ERROR",
                    statusCode = 400
                };
                return new BadRequestObjectResult(result);
            };
        }).AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
        });

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidAudience = jwtOptions.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key)),
            ClockSkew = TimeSpan.Zero
        };
    });

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowFrontend", policy =>
        {
            var frontendUrl = Environment.GetEnvironmentVariable("FRONTEND_URL") ?? "";
            policy.WithOrigins(frontendUrl)
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials();
        });
    });

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
    });

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    // else
    // {
    //     app.UseHttpsRedirection();
    // }

    // Security headers
    app.Use(async (ctx, next) =>
    {
        ctx.Response.Headers.Append("X-Content-Type-Options", "nosniff");
        ctx.Response.Headers.Append("X-Frame-Options", "DENY");
        ctx.Response.Headers.Append("X-XSS-Protection", "1; mode=block");
        await next();
    });

    app.UseCors("AllowFrontend");
    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseIpRateLimiting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "La aplicación falló al iniciar.");
}
finally
{
    Log.CloseAndFlush();
}