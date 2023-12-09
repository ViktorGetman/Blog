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
            CreateMap<UserEntity, UserModel>().ReverseMap();
            CreateMap<PostEntity, PostModel>().ReverseMap();
            CreateMap<TagEntity, TagModel>().ReverseMap();
            CreateMap<RoleEntity, RoleModel>().ReverseMap();
        }
    }
}
