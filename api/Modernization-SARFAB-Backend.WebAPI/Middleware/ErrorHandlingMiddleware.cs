﻿using Modernization_SARFAB_Backend.Application.Exceptions;
using Modernization_SARFAB_Backend.Domain.Exceptions;
using Modernization_SARFAB_Backend.Infrastructure.Exceptions;
using Serilog;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Modernization_SARFAB_Backend.WebAPI.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            Log.Error(ex, "ErrorHandlingMiddleware: Excepción no controlada para la ruta {Path}. Método: {Method}", context.Request.Path, context.Request.Method);

            var result = ex switch
            {
                BusinessException businessEx => new
                {
                    success = false,
                    message = businessEx.Message,
                    errorCode = "BUSINESS_ERROR",
                    statusCode = 400
                },
                DomainException domainEx => new
                {
                    success = false,
                    message = domainEx.Message,
                    errorCode = "DOMAIN_ERROR",
                    statusCode = 400
                },
                InfrastructureException infrastructureEx => new
                {
                    success = false,
                    message = infrastructureEx.Message,
                    errorCode = "INFRASTRUCTURE_ERROR",
                    statusCode = 500
                },
                _ => new
                {
                    success = false,
                    message = "Ocurrió un error interno en el servidor.",
                    errorCode = "INTERNAL_SERVER_ERROR",
                    statusCode = 500
                }
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = result.statusCode;
            return context.Response.WriteAsJsonAsync(result);
        }
    }
}