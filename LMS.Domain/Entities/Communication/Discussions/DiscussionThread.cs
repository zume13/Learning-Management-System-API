using LMS.Domain.Entities.Communication.Discussions;
using LMS.Domain.Entities.Communication.LessonDiscussions;
using LMS.SharedKernel.Primitives;
using SharedKernel.Shared;

public class DiscussionThread : Entity
{
    private readonly List<DiscussionReply> _replies = [];

    private DiscussionThread(
        Guid id,
        Guid contextId,
        DiscussionContextType contextType,
        Guid authorId,
        string title,
        string body) : base(id)
    {
        ContextId = contextId;
        ContextType = contextType;
        AuthorId = authorId;
        Title = title;
        Body = body;
        CreatedAt = DateTime.UtcNow;
    }

    public Guid ContextId { get; }

    public DiscussionContextType ContextType { get; }

    public Guid AuthorId { get; }

    public string Title { get; private set; }

    public string Body { get; private set; }

    public bool Locked { get; private set; }

    public bool Pinned { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public IReadOnlyCollection<DiscussionReply> Replies => _replies;

    public static ResultT<DiscussionThread> Create(
        Guid contextId,
        DiscussionContextType contextType,
        Guid authorId,
        string title,
        string body)
    {
        if(string.IsNullOrEmpty(title))
            return GeneralErrors.General.Empty(nameof(title));

        if(string.IsNullOrEmpty(body))
            return GeneralErrors.General.Empty(nameof(body));

        return new DiscussionThread(
            Guid.NewGuid(),
            contextId,
            contextType,
            authorId,
            title,
            body);
    }

    public Result AddReply(
    Guid authorId,
    string body,
    Guid? parentReplyId = null)
    {
        if (Locked)
            return DiscussionErrors.Thread.Locked;

        if (parentReplyId is not null &&
            !_replies.Any(r => r.Id == parentReplyId))
        {
            return DiscussionErrors.Thread.ReplyNotFound;
        }

        var result = DiscussionReply.Create(
            Id,
            authorId,
            body,
            parentReplyId);

        if (result.IsFailure)
            return result;

        _replies.Add(result.value);

        return Result.Success();
    }

    public void Lock() => Locked = true;

    public void Unlock() => Locked = false;

    public void Pin() => Pinned = true;
}