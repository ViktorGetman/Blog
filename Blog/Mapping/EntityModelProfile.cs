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
                .ForMember(dest => dest.RoleIds, opt => opt.MapFrom(src => src.Roles.Select(x=>x.RoleId).ToList()))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.Roles.Select(x => x.Role.RoleType).ToList()))
                .ReverseMap()
                .ForMember(dest => dest.Roles, opt => opt.Ignore());
            CreateMap<PostEntity, PostModel>().ReverseMap();
            CreateMap<TagEntity, TagModel>().ReverseMap();
            CreateMap<RoleEntity, RoleModel>().ReverseMap();
        }
    }
}
