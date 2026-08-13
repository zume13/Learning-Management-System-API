using LMS.Domain.Entities.Assignments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Infrastructure.Persistence.Configurations
{
    public sealed class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.ToTable("Assignments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.CourseId)
                .IsRequired();

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Description)
                .HasMaxLength(2000);

            builder.Property(x => x.DueDate)
                .IsRequired();

            builder.Property(x => x.AllowLate)
                .IsRequired();

            builder.Property(x => x.CreatedById)
                .IsRequired();

            builder.Property(x => x.AllowDiscussion)
                .IsRequired();

            builder.Navigation(x => x.Attachments)
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Navigation(x => x.Submissions)
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany(x => x.Attachments)
                .WithOne()
                .HasForeignKey("assignment-id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Submissions)
                .WithOne()
                .HasForeignKey("assignment-id")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}