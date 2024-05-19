using AutoMapper;
using LikeCommentFeedbackMicroservice.DTOs.Comment;
using LikeCommentFeedbackMicroservice.Models;

namespace LikeCommentFeedbackMicroservice.Mapping
{
    public class CommentMapping : Profile
    {
        public CommentMapping()
        {
            CreateMap<Comment, ReadCommentDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentDto>().ReverseMap();
            CreateMap<Comment, CreateCommentDto>().ReverseMap();
        }
    }
}
