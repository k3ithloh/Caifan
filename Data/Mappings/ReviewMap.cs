using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Caifan.Models;
using Caifan.Utilities;

namespace Caifan.Data.Mappings;

public class ReviewMap : BaseMap<Review>
{
    public ReviewMap(EntityTypeBuilder<Review> builder) : base(builder)
    {
        builder.HasKey(r => r.ReviewId);
        builder.Property(r => r.ReviewId).IsRequired();
        builder.Property(r => r.Rating).IsRequired();
        builder.Property(r => r.UserId).IsRequired();
        builder.Property(r => r.Timestamp).IsRequired();
        builder.Property(r => r.Description).IsRequired();
        builder.Property(r => r.UniversityName).IsRequired();

        builder.HasOne(r => r.University)
            .WithMany(r => r.Reviews)
            .HasForeignKey(r => r.UniversityName)
            .IsRequired();

        builder.HasOne(r => r.User)
            .WithMany(r => r.Reviews)
            .HasForeignKey(r => r.UserId)
            .IsRequired();
    }
}
