using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Caifan.Models;
using Caifan.Utilities;


namespace Caifan.Data.Mappings;

public class UserMap : BaseMap<User>
{
    public UserMap(EntityTypeBuilder<User> builder) : base(builder)
    {
        builder.HasKey(u => u.UserId);
        builder.Property(u => u.UserId).IsRequired();
        builder.Property(u => u.Username).IsRequired();
        builder.Property(u => u.Email).IsRequired();
        builder.Property(u => u.MobileNo).IsRequired();
        builder.Property(u => u.PasswordEncrypt).IsRequired();

        builder.HasMany(u => u.Reviews)
            .WithOne(u => u.User)
            .HasForeignKey(u => u.UserId)
            .IsRequired();

        builder.HasMany(u => u.DegreeUsers)
            .WithOne(u => u.User)
            .HasForeignKey(u => u.UserId)
            .IsRequired();
    }
}
