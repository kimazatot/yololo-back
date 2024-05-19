namespace LikeCommentFeedbackMicroservice.DTOs.Comment
{
    public class UpdateCommentDto
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
    }
    //public record UpdateCommentDto(int Id, int ReviewId, int UserId, string Content);
}
