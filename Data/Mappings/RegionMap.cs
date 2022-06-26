using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Caifan.Models;
using Caifan.Utilities;

namespace Caifan.Data.Mappings;

public class RegionMap : BaseMap<Region>
{
    public RegionMap(EntityTypeBuilder<Region> builder) : base(builder)
    {
        builder.HasKey(e => e.RegionId);
        builder.Property(e => e.RegionId).IsRequired();
        builder.Property(e => e.RegionName).IsRequired();

        builder.HasMany(e => e.Universities)
            .WithOne(e => e.Region)
            .HasForeignKey(e => e.RegionId)
            .IsRequired();
    }
}
