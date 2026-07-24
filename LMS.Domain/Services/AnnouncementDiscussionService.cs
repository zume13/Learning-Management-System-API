using LMS.Domain.Entities.Communication;
using LMS.Domain.Entities.Communication.Announcements;
using LMS.Domain.Entities.Communication.Discussions;
using LMS.Domain.Entities.Communication.LessonDiscussions;
using SharedKernel.Shared;

namespace LMS.Domain.Services;

public sealed class AnnouncementDiscussionService
{
    public ResultT<DiscussionThread> CreateThread(
        Announcement announcement,
        Guid authorId,
        string title,
        string body)
    {
        if (!announcement.AllowReplies)
            return AnnouncementErrors.RepliesDisabled;

        return DiscussionThread.Create(
            announcement.Id,
            DiscussionContextType.Announcement,
            authorId,
            title,
            body);
    }

    public Result CanReply(
        Announcement announcement,
        DiscussionThread thread)
    {
        if (!announcement.AllowReplies)
            return AnnouncementErrors.RepliesDisabled;

        if (thread.Locked)
            return DiscussionErrors.Locked;

        return Result.Success();
    }
}