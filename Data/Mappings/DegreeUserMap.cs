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
        builder.Property(e => e.UserId);
        builder.Property(e=>e.DegreeId);
        builder.Property(e => e.Primary);

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
