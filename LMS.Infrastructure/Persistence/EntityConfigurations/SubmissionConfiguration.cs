using LMS.Domain.Entities.Assignments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Infrastructure.Persistence.Configurations
{
    public sealed class SubmissionConfiguration
        : IEntityTypeConfiguration<Submission>
    {
        public void Configure(EntityTypeBuilder<Submission> builder)
        {
            builder.ToTable("Submissions");

            builder.HasIndex(x => new { x.AssignmentId, x.StudentId })
                .IsUnique();

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.AssignmentId)
                .IsRequired();

            builder.Property(x => x.StudentId)
                .IsRequired();

            builder.Property(x => x.SubmittedAt)
                .IsRequired();

            builder.Property(x => x.Feedback)
                .HasMaxLength(2000);

            builder.Property(x => x.Grade)
                .IsRequired(false);

            builder.Property(x => x.Status)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(50);

            builder.HasMany(x => x.Attachments)
                .WithOne()
                .HasForeignKey("SubmissionId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(x => x.Attachments)
                .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}