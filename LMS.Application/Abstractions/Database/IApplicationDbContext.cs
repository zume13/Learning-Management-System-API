
using LMS.Domain.Entities.Assessments;
using LMS.Domain.Entities.Assignments;
using LMS.Domain.Entities.Communication;
using LMS.Domain.Entities.Communication.Announcements;
using LMS.Domain.Entities.Communication.LessonDiscussions;
using LMS.Domain.Entities.Courses;
using LMS.Domain.Entities.Enrollments;
using LMS.Domain.Entities.Exams;
using LMS.Domain.Entities.Grades;
using LMS.Domain.Entities.Identity.Roles;
using LMS.Domain.Entities.Identity.Users;
using LMS.Domain.Entities.Lessons;
using LMS.Domain.Entities.Notifications;
using LMS.Domain.Entities.Sections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace LMS.Application.Abstractions.Database
{
    public interface IApplicationDbContext
    {
        #region user_aggregate
        DbSet<User> Users { get; }
        #endregion

        #region role_aggregate
        DbSet<Role> Roles { get; }
        DbSet<Permissions> Permissions { get; }
        #endregion

        #region assignment_aggregate
        DbSet<Assignment> Assignments { get; }
        DbSet<AssignmentAttachment> AssignmentAttachments { get; }
        DbSet<Submission> Submissions { get; }
        DbSet<SubmissionAttachment> SubmissionAttachments { get; }
        #endregion

        #region announcement_aggregate
        DbSet<Announcement> Announcements { get; }
        DbSet<AnnouncementComment> AnnouncementComments { get; }
        #endregion

        #region discussion_aggregate
        DbSet<DiscussionThread> DiscussionThreads { get; }
        DbSet<DiscussionReply> DiscussionReplies { get; }
        #endregion

        #region grade_consultation_aggregate
        DbSet<GradeConsultation> GradeConsultations { get; }
        #endregion

        #region notification_aggregate
        DbSet<Notification> Notifications { get; }
        #endregion

        #region course_aggregate
        DbSet<Course> Courses { get; }
        #endregion

        #region enrollment_aggregate
        DbSet<Enrollment> Enrollments { get; }
        #endregion

        #region exams_aggregate
        DbSet<Exam> Exams { get; }
        DbSet<ExamAnswer> ExamAnswers { get; }
        DbSet<ExamAttempt> ExamAttempts { get; }
        DbSet<ExamQuestion> ExamQuestions { get; }

        #endregion

        #region grade_aggregate
        DbSet<Grade> Grades { get; }
        #endregion

        #region lessons_aggregate
        DbSet<Lesson> Lessons { get; }
        DbSet<LessonFile> LessonFiles { get; }
        DbSet<VideoLesson> VideoLessons { get; }
        #endregion

        #region generator_aggregate
        DbSet<QuizGenerator> GenerateQuizJobs { get; }
        #endregion

        #region sections_aggregate
        DbSet<Section> Sections { get; }
        #endregion
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DatabaseFacade Database { get; }
    }
}
