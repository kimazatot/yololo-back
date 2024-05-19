using AutoMapper;
using LikeCommentFeedbackMicroservice.DTOs.Like;

namespace LikeCommentFeedbackMicroservice.Mapping
{
    public class LikeMapping : Profile
    {
        public LikeMapping()
        {
            CreateMap<Models.Like, CreateLikeDto>().ReverseMap();
            CreateMap<Models.Like, UpdateLikeDto>().ReverseMap();
            CreateMap<Models.Like, ReadLikeDto>().ReverseMap();
        }
    }
}
