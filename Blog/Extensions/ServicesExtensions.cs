using AutoMapper;
using Blog.BLL.Mappers;
using Blog.Mapping;

namespace Blog.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection serviceCollection)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new EntityModelProfile());
                mc.AddProfile(new ModelViewModelProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            serviceCollection.AddSingleton(mapper);
            return serviceCollection;
        }
    }
}
