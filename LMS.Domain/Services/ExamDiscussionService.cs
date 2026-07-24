using LMS.Domain.Entities.Communication.Discussions;
using LMS.Domain.Entities.Communication.LessonDiscussions;
using LMS.Domain.Entities.Exams;
using SharedKernel.Shared;

namespace LMS.Domain.Services;

public sealed class ExamDiscussionService
{
    public ResultT<DiscussionThread> CreateThread(
        Exam exam,
        Guid authorId,
        string title,
        string body)
    {
        if (!exam.AllowDiscussion)
            return ExamErrors.DiscussionDisabled;

        if (!exam.ResultsReleased)
            return ExamErrors.ResultsNotReleased;

        return DiscussionThread.Create(
            exam.Id,
            DiscussionContextType.Exam,
            authorId,
            title,
            body);
    }

    public Result CanReply(
        Exam exam,
        DiscussionThread thread)
    {
        if (!exam.ResultsReleased)
            return ExamErrors.ResultsNotReleased;

        if (thread.Locked)
            return DiscussionErrors.Locked;

        return Result.Success();
    }
}