using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Caifan.Models;
using Caifan.Utilities;

namespace Caifan.Data.Mappings;

public class DegreeUserMap : BaseMap<DegreeUser>
{
    public DegreeUserMap(EntityTypeBuilder<DegreeUser> builder) : base(builder)
    {
        builder.HasKey(e => new{ e.UserId, e.DegreeId});
        builder.Property(e => e.UserId).IsRequired();
        builder.Property(e=>e.DegreeId).IsRequired();
        builder.Property(e => e.Primary).IsRequired();

        builder.HasOne(e => e.User)
            .WithMany(e => e.DegreeUsers)
            .HasForeignKey(e => e.UserId)
            .IsRequired();

        builder.HasOne(e => e.Degree)
            .WithMany(e => e.DegreeUsers)
            .HasForeignKey(e => e.DegreeId)
            .IsRequired();

    }

}
