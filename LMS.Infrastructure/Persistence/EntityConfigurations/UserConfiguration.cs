using LMS.Domain.Entities.Identity.Roles;
using LMS.Domain.Entities.Identity.Users;
using LMS.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Infrastructure.Persistence.EntityConfigurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Email.value)
                .IsUnique();

            builder.Property(x => x.FirstName)
                .HasConversion(
                    v => v.value,
                    v => Name.Create(v).value)
                .HasColumnName("first_name");

            builder.Property(x => x.LastName)
                .HasConversion(
                   v => v.value,
                    v => Name.Create(v).value)
                .HasColumnName("last_name");

            builder.Property(x => x.Email)
                .HasConversion(
                    v => v.value,
                    v => Email.Create(v).value)
                .HasColumnName("email");

            builder.Property(x => x.HashedPassword)
                .IsRequired()
                .HasColumnName("hashed_password");

            builder.Metadata.FindNavigation("RoleIds")!
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.PrimitiveCollection<List<Guid>>("RoleIds")
                .HasColumnName("role_ids");
        }
    }
}
