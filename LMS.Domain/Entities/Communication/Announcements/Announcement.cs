using LMS.SharedKernel.Primitives;
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Communication;

public class Announcement : Entity
{
    private Announcement(
        Guid id,
        Guid courseId,
        Guid authorId,
        string title,
        string body,
        bool pinned,
        DateTime? scheduledAt,
        bool allowReplies) : base(id)
    {
        CourseId = courseId;
        AuthorId = authorId;
        Title = title;
        Body = body;
        Pinned = pinned;
        ScheduledAt = scheduledAt;
        CreatedAt = DateTime.UtcNow;
        AllowReplies = allowReplies;
    }

    public Guid CourseId { get; private set; }

    public Guid AuthorId { get; private set; }

    public string Title { get; private set; }

    public string Body { get; private set; }

    public bool Pinned { get; private set; }

    public bool AllowReplies { get; private set; }

    public DateTime? ScheduledAt { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public static ResultT<Announcement> Create(
        Guid courseId,
        Guid authorId,
        string title,
        string body,
        bool pinned = false,
        DateTime? scheduledAt = null, 
        bool allowReplies = false)
    {
        if (string.IsNullOrWhiteSpace(title))
            return GeneralErrors.General.Empty(nameof(title));

        if (string.IsNullOrWhiteSpace(body))
            return GeneralErrors.General.Empty(nameof(body));

        return new Announcement(
            Guid.NewGuid(),
            courseId,
            authorId,
            title,
            body,
            pinned,
            scheduledAt,
            allowReplies);
    }

    public void Pin() => Pinned = true;

    public void Unpin() => Pinned = false;

    public void Update(string title, string body)
    {
        Title = title;
        Body = body;
    }
}