using AutoMapper;
using Blog.BLL.Models;
using Blog.PLL.DTO.Comment;
using Blog.PLL.DTO.Post;
using Blog.PLL.DTO.Tag;
using Blog.PLL.DTO.User;

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
        }
    }
}
