using LMS.Domain.Entities.Communication.LessonDiscussions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public sealed class DiscussionThreadConfiguration
    : IEntityTypeConfiguration<DiscussionThread>
{
    public void Configure(EntityTypeBuilder<DiscussionThread> builder)
    {
        builder.ToTable("DiscussionThreads");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ContextId)
            .IsRequired();

        builder.Property(x => x.ContextType)
            .IsRequired();

        builder.Property(x => x.AuthorId)
            .IsRequired();

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Body)
            .IsRequired();

        builder.Property(x => x.Locked)
            .IsRequired();

        builder.Property(x => x.Pinned)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.HasMany<DiscussionReply>(x => x.Replies)
            .WithOne()
            .HasForeignKey(x => x.DiscussionThreadId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.Replies)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}