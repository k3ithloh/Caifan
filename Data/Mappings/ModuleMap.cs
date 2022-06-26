using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Caifan.Models;
using Caifan.Utilities;

namespace Caifan.Data.Mappings;

public class ModuleMap : BaseMap<Module>
{
    public ModuleMap(EntityTypeBuilder<Module> builder) : base(builder)
    {
        builder.HasKey(m => m.ModuleId);
        builder.Property(m => m.ModuleId).IsRequired();
        builder.Property(m => m.ModuleName).IsRequired();
        builder.Property(m => m.LinkToCourseOutline).IsRequired(false);
        builder.Property(m => m.Description).IsRequired();
        builder.Property(m=>m.Faculty).IsRequired();
        builder.Property(m => m.Faculty).IsRequired();
        builder.Property(m => m.Credits).IsRequired();
        
        builder.HasOne(m => m.University)
            .WithMany(m=>m.Modules)
            .HasForeignKey(m => m.UniversityName);

        builder.HasMany(m => m.Baskets)
            .WithMany(m => m.Modules)
            ;
        // .HasForeignKey<Module>(m => m.ModuleId)
        // .IsRequired();
    }
}

