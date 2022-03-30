using AutoMapper;
using BlogProject.Database.Models;
using BlogProject.Dtos.Posts;


namespace BlogProjectRefactor.Configuration.MapperProfiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, AddPostDto>();
            CreateMap<AddPostDto, Post>();

            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();

            CreateMap<Post, UpdatePostDto>();
            CreateMap<UpdatePostDto, Post>();
        }
    }
}
