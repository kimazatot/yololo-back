using LikeCommentFeedbackMicroservice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LikeCommentFeedbackMicroservice.Data.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.Property(r => r.Id).ValueGeneratedOnAdd();
            builder.Property(r => r.ProductId).IsRequired();
            builder.Property(r => r.Content).IsRequired();
        }
    }
}
