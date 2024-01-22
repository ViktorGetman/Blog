using AutoMapper;
using Blog.BLL.Models;
using Blog.DTO.Comment;
using Blog.DTO.Post;
using Blog.DTO.Role;
using Blog.DTO.Tag;
using Blog.DTO.User;
using Blog.DTO.UserRole;

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
            CreateMap<UpdateUserDto, UserModel>();
            CreateMap<AddPostDto, PostModel>().ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags.Select(x=> new TagModel() {Content=x})));
            CreateMap<UpdatePostDto, PostModel>().ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags.Select(x => new TagModel() { Content = x, PostId= src.Id }))); 
            CreateMap<AddTagDto, TagModel>();
            CreateMap<UpdateTagDto, TagModel>();
            CreateMap<RoleModel, RoleDto>().ReverseMap();
            CreateMap<AddRoleDto, RoleModel>();
            CreateMap<UpdateRoleDto, RoleModel>();
            CreateMap<AddUserDto, CreateUserModel>();
            CreateMap<EditUserRoleDto, EditUserRoleModel>();

        }
    }
}
