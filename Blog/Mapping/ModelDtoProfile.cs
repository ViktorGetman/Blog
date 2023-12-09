using AutoMapper;
using Blog.BLL.Models;
using Blog.PLL.DTO.Comment;
using Blog.PLL.DTO.Post;
using Blog.PLL.DTO.Tag;
using Blog.PLL.DTO.User;
using Blog.PLL.DTO.Role;

namespace Blog.Mapping
{
    public class ModelDtoProfile : Profile
    {
        public ModelDtoProfile()
        {
            CreateMap<CommentModel, CommentDto>().ReverseMap();
            CreateMap<UserModel, UserDto>().ReverseMap();
            CreateMap<PostModel, PostDto>().ReverseMap();
            CreateMap<TagModel, TagDto>().ReverseMap();
            CreateMap<AddCommentDto, CommentModel>();
            CreateMap<UpdateCommentDto, CommentModel>();
            CreateMap<AddUserDto, UserModel>();
            CreateMap<UpdateUserDto, UserModel>();
            CreateMap<AddPostDto, PostModel>();
            CreateMap<UpdatePostDto, PostModel>();
            CreateMap<AddTagDto, TagModel>();
            CreateMap<UpdateTagDto, TagModel>();
            CreateMap<RoleModel, RoleDto>().ReverseMap();
            CreateMap<AddRoleDto, RoleModel>();
            CreateMap<UpdateRoleDto, RoleModel>();
        }
    }
}
