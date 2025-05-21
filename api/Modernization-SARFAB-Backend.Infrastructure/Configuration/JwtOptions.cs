namespace Modernization_SARFAB_Backend.Infrastructure.Configuration;

public class JwtOptions
{
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
}