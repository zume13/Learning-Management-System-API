using LMS.Domain.Entities.Assignments;
using LMS.Domain.Entities.Communication.Discussions;
using LMS.Domain.Entities.Communication.LessonDiscussions;
using SharedKernel.Shared;

namespace LMS.Domain.Services;

public sealed class AssignmentDiscussionService
{
    public ResultT<DiscussionThread> CreateThread(
        Assignment assignment,
        Guid authorId,
        string title,
        string body)
    {
        if (!assignment.AllowDiscussion)
            return AssignmentErrors.DiscussionDisabled;

        if (assignment.IsClosed())
            return AssignmentErrors.AssignmentClosed;

        return DiscussionThread.Create(
            assignment.Id,
            DiscussionContextType.Assignment,
            authorId,
            title,
            body);
    }

    public Result CanReply(
        Assignment assignment,
        DiscussionThread thread)
    {
        if (assignment.IsClosed())
            return AssignmentErrors.AssignmentClosed;

        if (thread.Locked)
            return DiscussionErrors.Locked;

        return Result.Success();
    }
}