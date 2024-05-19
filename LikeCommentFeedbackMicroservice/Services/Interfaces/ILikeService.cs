using LikeCommentFeedbackMicroservice.DTOs.Like;
using LikeCommentFeedbackMicroservice.Models;

namespace LikeCommentFeedbackMicroservice.Services.Interfaces
{
    public interface ILikeService
    {
        Task<ReadLikeDto> AddLikeAsync(CreateLikeDto dto);
        Task RemoveLikeAsync(int likeId);
        Task<IEnumerable<ReadLikeDto>> GetLikesByReviewIdAsync(int reviewId);
        Task<ReadLikeDto> GetLikeByIdAsync(int likeId);
    }
}
