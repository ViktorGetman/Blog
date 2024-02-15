using AutoMapper;
using Blog.API.Mapping;
using Blog.BLL.Mappers;

namespace Blog.API.Extensions;

public static class ServiceExtensions {
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
}