using AutoMapper;
using Blog.BLL.Models;
using Blog.PLL.ViewModel.Comment;
using Blog.PLL.ViewModel.Post;
using Blog.PLL.ViewModel.Role;
using Blog.PLL.ViewModel.Tag;
using Blog.PLL.ViewModel.User;

namespace Blog.Mapping
{
    public class ModelViewModelProfile : Profile
    {
        public ModelViewModelProfile()
        {
            CreateMap<PostModel, PostShortViewModel>()
                .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.CommentsCount, opt => opt.MapFrom(src => src.Comments.Count))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags.Select(x => x.Content).ToArray()))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email));

            CreateMap<PostModel, PostViewModel>()
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags.Select(x => x.Content).ToArray()));

            CreateMap<CommentModel, CommentViewModel>();

            CreateMap<UserModel, UserShortViewModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.PostsCount, opt => opt.MapFrom(src => src.Posts.Count))
                .ForMember(dest => dest.CommentsCount, opt => opt.MapFrom(src => src.Comments.Count))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.Roles.Select(x=> x.Name))); 

            CreateMap<UserShortModel, UserShortViewModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<TagStatisticModel, TagViewModel>();

            CreateMap<UserModel, UserViewModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.CommentsCount, opt => opt.MapFrom(src => src.Comments.Count))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.Roles.Select(x => x.Name)));
            
            CreateMap<RoleModel, RoleViewModel>();
            CreateMap<RoleShortModel, RoleViewModel>();






        }
    }
}
