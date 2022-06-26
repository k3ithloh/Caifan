using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Caifan.Models;
using Caifan.Utilities;

namespace Caifan.Data.Mappings;

public class UniversityMap : BaseMap<University>
{
    public UniversityMap(EntityTypeBuilder<University> builder) : base(builder)
    {
        builder.HasKey(u => u.UniversityName);
        builder.Property(u => u.UniversityName).IsRequired();
        builder.Property(u => u.Icon).IsRequired();
        builder.Property(u => u.WorldRanking).IsRequired();
        builder.Property(u => u.Description).IsRequired();
        builder.Property(u => u.RegionId).IsRequired();
        builder.Property(u => u.CountryId).IsRequired();
        builder.Property(u => u.Address).IsRequired();
        builder.Property(u => u.AcademicCalendar).IsRequired();
        builder.Property(u => u.AcademicCalendarLink).IsRequired();
        builder.Property(u => u.GpaRequirement).IsRequired();
        builder.Property(u => u.NoOfPlacesSem1).IsRequired();
        builder.Property(u => u.NoOfPlacesSem2).IsRequired();
        builder.Property(u => u.IgpaTenPercentile).IsRequired();
        builder.Property(u => u.IgpaNinetyPercentile).IsRequired();
        builder.Property(u=>u.Accommodation).IsRequired();
        builder.Property(u => u.Insurance).IsRequired();
        builder.Property(u => u.Visa).IsRequired();
        builder.Property(u=>u.HostUniversityWebsite).IsRequired();
        builder.Property(u => u.HostUniversityExchangeWebsite).IsRequired();
        builder.Property(u=>u.CourseCatalogLink).IsRequired();
        builder.Property(u => u.CreditLoadMin).IsRequired();
        builder.Property(u=>u.CreditLoadMax).IsRequired();

        builder.HasOne(u => u.Region)
            .WithMany(u => u.Universities)
            .HasForeignKey(u => u.RegionId)
            .IsRequired();

        builder.HasOne(u => u.Country)
            .WithMany(u => u.Universities)
            .HasForeignKey(u => u.CountryId)
            .IsRequired();

        builder.HasMany(u => u.Degrees)
            .WithMany(u => u.Universities);

        builder.HasMany(u => u.Modules)
            .WithOne(u => u.University)
            .HasForeignKey(u => u.UniversityName)
            .IsRequired();

        builder.HasMany(u => u.Reviews)
            .WithOne(u => u.University)
            .HasForeignKey(u => u.UniversityName)
            .IsRequired();

    }
}

