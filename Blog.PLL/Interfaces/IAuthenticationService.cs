using Blog.BLL.Models;

namespace Blog.BLL.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<UserModel> Login(string email, string password);
    }
}
