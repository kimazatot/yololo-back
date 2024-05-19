using LikeCommentFeedbackMicroservice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LikeCommentFeedbackMicroservice.Data.Configurations
{
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.Property(r => r.Id).ValueGeneratedOnAdd();
            builder.Property(r => r.ProductId).IsRequired();
            builder.Property(r => r.ReviewId).IsRequired();
            builder.Property(r => r.UserId).IsRequired();
        }
    }
}
