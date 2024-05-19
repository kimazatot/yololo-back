using LikeCommentFeedbackMicroservice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LikeCommentFeedbackMicroservice.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(r => r.Id).ValueGeneratedOnAdd();
            //builder.Property(r => r.ReviewId).IsRequired();
            builder.Property(r => r.ProductId).IsRequired();
            builder.Property(r => r.Content).IsRequired();
        }
    }
}
