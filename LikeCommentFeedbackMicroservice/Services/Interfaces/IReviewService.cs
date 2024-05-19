using LikeCommentFeedbackMicroservice.DTOs.Review;

namespace LikeCommentFeedbackMicroservice.Services.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<ReadReviewDto>> GetReviewsAsync();
        Task<IEnumerable<ReadReviewDto>> GetReviewsByProductAsync(int productId);
        Task<ReadReviewDto> GetReviewByIdAsync(int reviewId);
        Task<ReadReviewDto> CreateReviewAsync(CreateReviewDto dto);
        Task<ReadReviewDto> UpdateReviewAsync(UpdateReviewDto dto);
        Task<ReadReviewDto> DeleteReviewAsync(int reviewId);
    }
}
