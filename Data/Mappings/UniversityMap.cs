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
        builder.Property(u => u.WorldRanking).IsRequired(false);
        builder.Property(u => u.Description).IsRequired();
        builder.Property(u => u.RegionId).IsRequired();
        builder.Property(u => u.CountryId).IsRequired();
        builder.Property(u => u.Address).IsRequired();
        builder.Property(u => u.AcademicCalendar).IsRequired(false);
        builder.Property(u => u.AcademicCalendarLink).IsRequired(false);
        builder.Property(u => u.GpaRequirement).IsRequired(false);
        builder.Property(u => u.NoOfPlacesSem1).IsRequired(false);
        builder.Property(u => u.NoOfPlacesSem2).IsRequired(false);
        builder.Property(u => u.IgpaTenPercentile).IsRequired(false);
        builder.Property(u => u.IgpaNinetyPercentile).IsRequired(false);
        builder.Property(u=>u.Accommodation).IsRequired(false);
        builder.Property(u => u.Insurance).IsRequired(false);
        builder.Property(u => u.Visa).IsRequired(false);
        builder.Property(u=>u.HostUniversityWebsite).IsRequired();
        builder.Property(u => u.HostUniversityExchangeWebsite).IsRequired(false);
        builder.Property(u=>u.CourseCatalogLink).IsRequired(false);
        builder.Property(u => u.CreditLoadMin).IsRequired(false);
        builder.Property(u=>u.CreditLoadMax).IsRequired(false);
        builder.Property(u => u.CreditTransferRate).IsRequired();
        builder.Property(u => u.ApplicationDeadline).IsRequired(false);
        builder.Property(u => u.Latitude).IsRequired();
        builder.Property(u => u.Longitude).IsRequired();
        builder.Property(u => u.Img1).IsRequired(false);
        builder.Property(u => u.Img2).IsRequired(false);
        builder.Property(u => u.Img3).IsRequired(false);
        builder.Property(u => u.Img4).IsRequired(false);
        builder.Property(u => u.Img5).IsRequired(false);
        builder.Property(u => u.Img6).IsRequired(false);
        
        

        builder.HasOne(u => u.Region)
            .WithMany(u => u.Universities)
            .HasForeignKey(u => u.RegionId)
            .IsRequired();

        builder.HasOne(u => u.Country)
            .WithMany(u => u.Universities)
            .HasForeignKey(u => u.CountryId)
            .IsRequired();

        builder.HasMany(u => u.DegreeUniversities)
            .WithOne(u => u.University)
            .HasForeignKey(e => e.UniversityName)
            .IsRequired();

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

