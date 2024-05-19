using System.ComponentModel.DataAnnotations.Schema;

namespace LikeCommentFeedbackMicroservice.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal? Rating { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Like> Likes { get; set; }
    }
}
