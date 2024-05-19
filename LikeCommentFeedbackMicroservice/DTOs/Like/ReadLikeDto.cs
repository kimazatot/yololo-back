namespace LikeCommentFeedbackMicroservice.DTOs.Like
{
    public class ReadLikeDto
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
