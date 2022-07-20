using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Caifan.Models;
using Caifan.Utilities;

namespace Caifan.Data.Mappings;

public class BasketMap : BaseMap<Basket>
{
    public BasketMap(EntityTypeBuilder<Basket> builder) : base(builder)
    {
        builder.HasKey(e => e.BasketId);
        builder.Property(e => e.BasketId).IsRequired();
        builder.Property(e => e.BasketName).IsRequired();

        builder.HasMany(e => e.BasketModules)
            .WithOne(e => e.Basket)
            .HasForeignKey(e => e.BasketId)
            .IsRequired();
    }
        
}