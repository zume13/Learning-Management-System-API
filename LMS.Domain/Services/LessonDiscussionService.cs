using LMS.Domain.Entities.Communication.Discussions;
using LMS.Domain.Entities.Communication.LessonDiscussions;
using LMS.Domain.Entities.Lessons;
using SharedKernel.Shared;

namespace LMS.Domain.Services;

public sealed class LessonDiscussionService
{
    public ResultT<DiscussionThread> CreateThread(
        Lesson lesson,
        Guid authorId,
        string title,
        string body)
    {
        if (!lesson.Published)
            return LessonErrors.NotPublished;

        if (!lesson.AllowDiscussion)
            return LessonErrors.DiscussionDisabled;

        return DiscussionThread.Create(
            lesson.Id,
            DiscussionContextType.Lesson,
            authorId,
            title,
            body);
    }

    public Result CanReply(
        Lesson lesson,
        DiscussionThread thread)
    {
        if (!lesson.AllowDiscussion)
            return LessonErrors.DiscussionDisabled;

        if (thread.Locked)
            return DiscussionErrors.Locked;

        return Result.Success();
    }
}