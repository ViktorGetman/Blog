using AutoMapper;
using Blog.BLL.Interfaces;
using Blog.BLL.Services;
using Blog.Mapping;

namespace Blog.Extansions
{
    public static class ServicesExtantions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection serviceCollection)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new EntityModelProfile());
                mc.AddProfile(new ModelDtoProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            serviceCollection.AddSingleton(mapper);
            return serviceCollection;
        }
        public static IServiceCollection AddBlogServices(this IServiceCollection serviceCollection)
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
