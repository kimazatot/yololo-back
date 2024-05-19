using LikeCommentFeedbackMicroservice.DTOs.Comment;

namespace LikeCommentFeedbackMicroservice.Services.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<ReadCommentDto>> GetCommentsAsync();
        Task<IEnumerable<ReadCommentDto>> GetCommentsByProductAsync(int productId);
        Task<ReadCommentDto> GetCommentByIdAsync(int commentId);
        Task<ReadCommentDto> CreateCommentAsync(CreateCommentDto dto);
        Task<ReadCommentDto> UpdateCommentAsync(UpdateCommentDto dto);
        Task<ReadCommentDto> DeleteCommentAsync(int id);
    }
}
