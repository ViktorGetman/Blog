using System.IdentityModel.Tokens.Jwt;

namespace Blog.Infrastructure.JwtAuthentication
{
    public interface IAuthenticationService
    {
        Task<(JwtSecurityToken? token, bool isSuccess)> TryLogin(string email, string password);
    }
}
