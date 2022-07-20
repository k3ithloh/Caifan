using Caifan.Models;
using Caifan.Utilities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Caifan.Data.Mappings;

public class DegreeUniversityMap : BaseMap<DegreeUniversity>
{
    public DegreeUniversityMap(EntityTypeBuilder<DegreeUniversity> builder) : base(builder)
    {
        builder.HasKey(e => new{ e.DegreeId, e.UniversityName});
        builder.Property(e => e.DegreeId).IsRequired();
        builder.Property(e=>e.UniversityName).IsRequired();

        builder.HasOne(e => e.University)
            .WithMany(e => e.DegreeUniversities)
            .HasForeignKey(e => e.UniversityName)
            .IsRequired();

        builder.HasOne(e => e.Degree)
            .WithMany(e => e.DegreeUniversities)
            .HasForeignKey(e => e.DegreeId)
            .IsRequired();

    }
}