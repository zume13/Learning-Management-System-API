using LMS.Domain.Entities.Assignments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Infrastructure.Persistence.Configurations
{
    public sealed class AssignmentAttachmentConfiguration
        : IEntityTypeConfiguration<AssignmentAttachment>
    {
        public void Configure(EntityTypeBuilder<AssignmentAttachment> builder)
        {
            builder.ToTable("AssignmentAttachment");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.AssignmentId)
                .IsRequired();

            builder.Property(x => x.BucketKey)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.FileName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.ContentType)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.SizeBytes)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(50);

            builder.Property(x => x.UploadedAt)
                .IsRequired();

            builder.HasOne<Assignment>()
                .WithMany(x => x.Attachments)
                .HasForeignKey(x => x.AssignmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}