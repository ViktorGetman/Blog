namespace Blog.Infrastructure.JwtAuthentication.Data;

internal class JwtTokenConfiguration
{
    public bool ValidateIssuer { get; set; }
    public string? Issuer { get; set; }
    public bool ValidateAudience { get; set; }
    public string? Audience { get; set; }
    public bool ValidateLifetime { get; set; }
    public int LifetimeSeconds { get; set; }
    public string Key { get; set; }
    public bool ValidateIssuerSigningKey { get; set; }
}