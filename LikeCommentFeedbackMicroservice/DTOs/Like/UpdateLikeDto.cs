namespace LikeCommentFeedbackMicroservice.DTOs.Like
{
    public class UpdateLikeDto
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
