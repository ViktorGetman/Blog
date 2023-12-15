﻿using AutoMapper;
using Blog.BLL.Models;
using Blog.PLL.ViewModel;
using Blog.PLL.ViewModel.Post;
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
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags.Select(x => x.Content).ToArray()));

            CreateMap<PostModel, PostViewModel>()
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags.Select(x => x.Content).ToArray()));

            CreateMap<CommentModel, CommentViewModel>();

            CreateMap<UserModel, UserShortViewModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<UserShortModel, UserShortViewModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));




        }
    }
}