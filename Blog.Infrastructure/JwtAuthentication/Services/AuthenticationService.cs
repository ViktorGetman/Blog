using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Blog.DAL;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.JwtAuthentication.Services
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly IDbContextFactory<BlogDbContext> _contextFactory;
        private readonly JwtTokenFactory _jwtTokenFactory;

        public AuthenticationService(IDbContextFactory<BlogDbContext> contextFactory, JwtTokenFactory jwtTokenFactory)
        {
            _contextFactory = contextFactory;
            _jwtTokenFactory = jwtTokenFactory;
        }
        public async Task<(JwtSecurityToken? token, bool isSuccess)> TryLogin(string email, string password)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            var entity = await context.Users.Include(x => x.Roles).ThenInclude(x => x.Role)
                .FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
            if (entity == null) 
            {
                return (null, false);
            }
            var roleClaims = entity.Roles.Select(x => new Claim(ClaimTypes.Role, x.Role.RoleType.ToString()));
            var claims = new List<Claim>
            {
                new(ClaimsIdentity.DefaultNameClaimType, entity.Email),
                new(ClaimTypes.Name, $"{entity.FirstName} {entity.LastName}"),
                new("Id", entity.Id.ToString()),
            };
            claims.AddRange(roleClaims);
            return (_jwtTokenFactory.CreateSecurity(claims), true);
        }
    }
}
