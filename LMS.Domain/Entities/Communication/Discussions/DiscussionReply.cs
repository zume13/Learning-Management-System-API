using LMS.SharedKernel.Primitives;
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Communication.LessonDiscussions;

public class DiscussionReply : Entity
{
    private DiscussionReply(
        Guid id,
        Guid discussionThreadId,
        Guid authorId,
        string body,
        Guid? parentReplyId)
        : base(id)
    {
        DiscussionThreadId = discussionThreadId;
        AuthorId = authorId;
        Body = body;
        ParentReplyId = parentReplyId;
        CreatedAt = DateTime.UtcNow;
    }

    public Guid DiscussionThreadId { get; }

    public Guid AuthorId { get; }

    public string Body { get; private set; }

    public Guid? ParentReplyId { get; }

    public DateTime CreatedAt { get; }

    public static ResultT<DiscussionReply> Create(
        Guid discussionThreadId,
        Guid authorId,
        string body,
        Guid? parentReplyId = null)
    {
        if (string.IsNullOrWhiteSpace(body))
            return GeneralErrors.General.Empty(nameof(body));

        return new DiscussionReply(
            Guid.NewGuid(),
            discussionThreadId,
            authorId,
            body,
            parentReplyId);
    }

    public Result Edit(string body)
    {
        if (string.IsNullOrWhiteSpace(body))
            return GeneralErrors.General.Empty(nameof(body));

        Body = body;

        return Result.Success();
    }
}