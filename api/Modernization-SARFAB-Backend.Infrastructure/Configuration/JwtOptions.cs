namespace Modernization_SARFAB_Backend.WebAPI.Configuration;

public class JwtOptions
{
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
}