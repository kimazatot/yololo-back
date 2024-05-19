namespace LikeCommentFeedbackMicroservice.DTOs.Comment
{
    public class ReadCommentDto
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
    //public record ReadCommentDto(int Id, int ReviewId, int UserId, string Content, DateTime CreatedAt);
}
