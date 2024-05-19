using LikeCommentFeedbackMicroservice.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace LikeCommentFeedbackMicroservice.DTOs.Review
{
    public class ReadReviewDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal? Rating { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Models.Like> Likes { get; set; }
    }
}
