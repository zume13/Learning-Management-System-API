using LMS.SharedKernel.Primitives;
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Communication.LessonDiscussions;

public class DiscussionReply : Entity
{
    private readonly List<DiscussionReply> _replies = [];

    private DiscussionReply(
        Guid id,
        Guid discussionThreadId,
        Guid authorId,
        string body,
        Guid? parentReplyId) : base(id)
    {
        DiscussionThreadId = discussionThreadId;
        AuthorId = authorId;
        Body = body;
        ParentReplyId = parentReplyId;
        CreatedAt = DateTime.UtcNow;
    }

    public Guid DiscussionThreadId { get; private set; }

    public Guid AuthorId { get; private set; }

    public string Body { get; private set; }

    public Guid? ParentReplyId { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public IReadOnlyCollection<DiscussionReply> Replies => _replies;

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

    public void Edit(string body)
    {
        Body = body;
    }

    public void AddReply(DiscussionReply reply)
    {
        _replies.Add(reply);
    }
}