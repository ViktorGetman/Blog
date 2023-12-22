using AutoMapper;
using Blog.BLL.Models;
using Blog.DAL.Entities;

namespace Blog.Mapping
{
    public class EntityModelProfile: Profile
    {
        public EntityModelProfile() 
        {
            CreateMap<CommentEntity, CommentModel>().ReverseMap();
            CreateMap<UserEntity, UserModel>()
                .ReverseMap();
            CreateMap<PostEntity, PostModel>().ReverseMap();
            CreateMap<TagEntity, TagModel>().ReverseMap();
            CreateMap<RoleEntity, RoleModel>()
                .ForMember(dest => dest.UserCount, opt => opt.MapFrom(src => src.Users.Count))
                .ReverseMap();
            CreateMap<UserEntity, UserShortModel>().ReverseMap();
            CreateMap<UserRoleEntity, RoleShortModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Role.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Role.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Role.Description))
                .ForMember(dest => dest.RoleType, opt => opt.MapFrom(src => src.Role.RoleType));
        }
    }
}
