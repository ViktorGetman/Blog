using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Blog.Infrastructure.JwtAuthentication.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Infrastructure.JwtAuthentication.Services;

public class JwtTokenFactory
{
    private readonly IConfigurationSection _section;

    public JwtTokenFactory(IConfigurationSection section)
    {
        _section = section;
    }

    public TokenValidationParameters CreateValidationParameters()
    {
        var configuration = _section.Get<JwtTokenConfiguration>()!;
        return new TokenValidationParameters
        {
            ValidateIssuer = configuration.ValidateIssuer,
            ValidIssuer = configuration.Issuer,
            ValidateAudience = configuration.ValidateAudience,
            ValidAudience = configuration.Audience,
            ValidateLifetime = configuration.ValidateLifetime,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.Key)),
            ValidateIssuerSigningKey = configuration.ValidateIssuerSigningKey,
        };
    }

    public JwtSecurityToken CreateSecurity(IEnumerable<Claim> claims)
    {
        var configuration = _section.Get<JwtTokenConfiguration>()!;
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.Key));
        return new JwtSecurityToken(
            issuer: configuration.Issuer,
            audience: configuration.Audience,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromSeconds(configuration.LifetimeSeconds)),
            signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256));
    }
}