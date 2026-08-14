using LMS.Domain.Entities.Communication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Infrastructure.Persistence.Configurations
{
    public sealed class AnnouncementConfiguration
        : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.ToTable("Announcements");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.CourseId)
                .IsRequired();

            builder.Property(x => x.AuthorId)
                .IsRequired();

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Body)
                .IsRequired()
                .HasMaxLength(5000);

            builder.Property(x => x.Pinned)
                .IsRequired();

            builder.Property(x => x.AllowReplies)
                .IsRequired();

            builder.Property(x => x.ScheduledAt)
                .IsRequired(false);

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.HasIndex(x => x.CourseId);

            builder.HasIndex(x => x.ScheduledAt);

            builder.HasIndex(x => new { x.CourseId, x.Pinned });
        }
    }
}