using LMS.Domain.Entities.Identity.Permissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Infrastructure.Persistence.EntityConfigurations;

internal sealed class PermissionConfiguration
    : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("Permissions");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.PermissionName)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("permission_name");

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(500)
            .HasColumnName("description");

        builder.HasIndex(x => x.PermissionName)
            .IsUnique();
    }
}