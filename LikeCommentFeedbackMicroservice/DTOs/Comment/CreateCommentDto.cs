namespace LikeCommentFeedbackMicroservice.DTOs.Comment
{
    public class CreateCommentDto
    {
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
    }
    //public record CreateCommentDto(int ReviewId, int UserId, string Content);
}
