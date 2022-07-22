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
        builder.Property(m => m.Description).IsRequired(false);
        builder.Property(m => m.Year).IsRequired(false);
        builder.Property(m => m.Semester).IsRequired(false);
        builder.Property(m => m.Difficulty).IsRequired(false);
        builder.Property(m => m.Popularity).IsRequired(false);
        builder.Property(m=>m.Faculty).IsRequired();
        builder.Property(m => m.Faculty).IsRequired();
        builder.Property(m => m.Credits).IsRequired();
        
        builder.HasOne(m => m.University)
            .WithMany(m=>m.Modules)
            .HasForeignKey(m => m.UniversityName);

        builder.HasMany(m => m.BasketModules)
            .WithOne(m => m.Module)
            .HasForeignKey(e => e.ModuleId)
            .IsRequired();
    }
}

