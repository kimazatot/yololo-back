using LikeCommentFeedbackMicroservice.Models;

namespace LikeCommentFeedbackMicroservice.DTOs.Like
{
    public class CreateLikeDto
    {
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
