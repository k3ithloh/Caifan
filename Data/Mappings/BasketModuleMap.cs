using Caifan.Models;
using Caifan.Utilities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Caifan.Data.Mappings;

public class BasketModuleMap : BaseMap<BasketModule>
{
    public BasketModuleMap(EntityTypeBuilder<BasketModule> builder) : base(builder)
    {
        builder.HasKey(e => new{ e.BasketId, e.ModuleId});
        builder.Property(e => e.BasketId).IsRequired();
        builder.Property(e=>e.ModuleId).IsRequired();

        builder.HasOne(e => e.Module)
            .WithMany(e => e.BasketModules)
            .HasForeignKey(e => e.ModuleId)
            .IsRequired();

        builder.HasOne(e => e.Basket)
            .WithMany(e => e.BasketModules)
            .HasForeignKey(e => e.BasketId)
            .IsRequired();

    }
}