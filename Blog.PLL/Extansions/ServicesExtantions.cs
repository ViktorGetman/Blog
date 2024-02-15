using Blog.BLL.Interfaces;
using Blog.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.BLL.Extansions
{
    public static class BllServicesExtensions
    {
        public static IServiceCollection AddBlogBllServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ICommentService, CommentService>();
            serviceCollection.AddSingleton<IPostService, PostService>();
            serviceCollection.AddSingleton<IUserService, UserService>();
            serviceCollection.AddSingleton<ITagService, TagService>();
            serviceCollection.AddSingleton<IRoleService, RoleService>();
            return serviceCollection;
        }
    }
}
