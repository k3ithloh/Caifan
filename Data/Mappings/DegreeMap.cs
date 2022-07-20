using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Caifan.Models;
using Caifan.Utilities;

namespace Caifan.Data.Mappings;

public class DegreeMap : BaseMap<Degree>
{
    public DegreeMap(EntityTypeBuilder<Degree> builder) : base(builder)
    {
        builder.HasKey(e => e.DegreeId);
        builder.Property(e => e.DegreeId).IsRequired();
        builder.Property(e => e.DegreeName).IsRequired();

        builder.HasMany(e => e.DegreeUniversities)
            .WithOne(e => e.Degree)
            .HasForeignKey(e => e.DegreeId)
            .IsRequired();
        
        builder.HasMany(e => e.DegreeUsers)
            .WithOne(e => e.Degree)
            .HasForeignKey(e => e.DegreeId)
            .IsRequired();
    }
}