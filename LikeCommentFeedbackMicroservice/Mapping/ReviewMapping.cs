using AutoMapper;
using LikeCommentFeedbackMicroservice.DTOs.Review;
using LikeCommentFeedbackMicroservice.Models;

namespace LikeCommentFeedbackMicroservice.Mapping
{
    public class ReviewMapping : Profile
    {
        public ReviewMapping()
        {
            CreateMap<Review, ReadReviewDto>().ReverseMap();
            CreateMap<Review, CreateReviewDto>().ReverseMap();
            CreateMap<Review, UpdateReviewDto>().ReverseMap();
        }
    }
}
