using SharedKernel.Shared;

namespace LMS.Domain.Services;

public static class DiscussionErrors
{
    public static readonly Error Locked = Error.Conflict(
        "Discussion.Locked",
        "The discussion thread is locked.");

    public static readonly Error AlreadyLocked = Error.Conflict(
        "Discussion.AlreadyLocked",
        "The discussion thread is already locked.");

    public static readonly Error AlreadyUnlocked = Error.Conflict(
        "Discussion.AlreadyUnlocked",
        "The discussion thread is already unlocked.");

    public static readonly Error AlreadyPinned = Error.Conflict(
        "Discussion.AlreadyPinned",
        "The discussion thread is already pinned.");

    public static readonly Error AlreadyUnpinned = Error.Conflict(
        "Discussion.AlreadyUnpinned",
        "The discussion thread is already unpinned.");
}

public static class LessonErrors
{
    public static readonly Error NotPublished = Error.Conflict(
        "Lesson.NotPublished",
        "The lesson has not been published.");

    public static readonly Error DiscussionDisabled = Error.Conflict(
        "Lesson.DiscussionDisabled",
        "Discussions are disabled for this lesson.");

    public static readonly Error FileAlreadyAttached = Error.Conflict(
        "Lesson.FileAlreadyAttached",
        "The file is already attached to the lesson.");

    public static readonly Error FileNotFound = Error.NotFound(
        "Lesson.FileNotFound",
        "The file was not found in this lesson.");

    public static readonly Error VideoAlreadyAttached = Error.Conflict(
        "Lesson.VideoAlreadyAttached",
        "The video is already attached to the lesson.");

    public static readonly Error VideoNotFound = Error.NotFound(
        "Lesson.VideoNotFound",
        "The video was not found in this lesson.");
}

public static class AssignmentErrors
{
    public static readonly Error AssignmentClosed = Error.Conflict(
        "Assignment.Closed",
        "The assignment is already closed.");

    public static readonly Error DiscussionDisabled = Error.Conflict(
        "Assignment.DiscussionDisabled",
        "Discussions are disabled for this assignment.");
}

public static class ExamErrors
{
    public static readonly Error ResultsNotReleased = Error.Conflict(
        "Exam.ResultsNotReleased",
        "The exam results have not been released.");

    public static readonly Error DiscussionDisabled = Error.Conflict(
        "Exam.DiscussionDisabled",
        "Discussions are disabled for this exam.");
}

public static class AnnouncementErrors
{
    public static readonly Error RepliesDisabled = Error.Conflict(
        "Announcement.RepliesDisabled",
        "Replies are disabled for this announcement.");

    public static readonly Error Archived = Error.Conflict(
        "Announcement.Archived",
        "The announcement has been archived.");
}

public static class GradeErrors
{
    public static readonly Error NotReleased = Error.Conflict(
        "Grade.NotReleased",
        "The grade has not yet been released.");

    public static readonly Error NotFound = Error.NotFound(
        "Grade.NotFound",
        "The requested grade could not be found.");
}

public static class GradeConsultationErrors
{
    public static readonly Error AlreadyResponded = Error.Conflict(
        "GradeConsultation.AlreadyResponded",
        "The consultation has already been responded to.");

    public static readonly Error CannotModify = Error.Conflict(
        "GradeConsultation.CannotModify",
        "Only pending consultations can be modified.");

    public static readonly Error NotResponded = Error.Conflict(
        "GradeConsultation.NotResponded",
        "The consultation has not been responded to.");

    public static readonly Error AlreadyClosed = Error.Conflict(
        "GradeConsultation.AlreadyClosed",
        "The consultation has already been closed.");
}