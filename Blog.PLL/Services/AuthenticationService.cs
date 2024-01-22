using AutoMapper;
using Blog.BLL.Interfaces;
using Blog.BLL.Models;
using Blog.DAL;
using Microsoft.EntityFrameworkCore;

namespace Blog.BLL.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IDbContextFactory<BlogDbContext> _contextFactory;
        private readonly IMapper _mapper;
        public AuthenticationService(IDbContextFactory<BlogDbContext> contextFactory, IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }
        public async Task<UserModel?> Login(string email, string password)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            var entity = await context.Users.Include(x => x.Roles).ThenInclude(x => x.Role)
                .FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
            if (entity == null) 
            {
                return null;
            }
            return _mapper.Map<UserModel>(entity);
        }
    }
}
