using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Caifan.Models;
using Caifan.Utilities;

namespace Caifan.Data.Mappings;

public class CountryMap : BaseMap<Country>
{
    public CountryMap(EntityTypeBuilder<Country> builder) : base(builder)
    {
        builder.HasKey (c => c.CountryId);
        builder.Property(c => c.CountryId).IsRequired();
        builder.Property(c => c.CountryName).IsRequired();

        builder.HasMany(c => c.Universities)
            .WithOne(c => c.Country)
            .HasForeignKey(c=>c.CountryId)
            .IsRequired();
        
    }
}