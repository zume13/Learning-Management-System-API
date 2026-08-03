using LMS.Application.Abstractions.Repositories;
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
using LMS.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Persistence.Database
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();

        public DbSet<Role> Roles => Set<Role>();

        public DbSet<Permissions> Permissions => Set<Permissions>();

        public DbSet<Assignment> Assignments => Set<Assignment>();

        public DbSet<AssignmentAttachment> AssignmentAttachments => Set<AssignmentAttachment>();

        public DbSet<Submission> Submissions => Set<Submission>();

        public DbSet<SubmissionAttachment> SubmissionAttachments => Set<SubmissionAttachment>();

        public DbSet<Announcement> Announcements => Set<Announcement>();

        public DbSet<AnnouncementComment> AnnouncementComments => Set<AnnouncementComment>();

        public DbSet<DiscussionThread> DiscussionThreads => Set<DiscussionThread>();

        public DbSet<DiscussionReply> DiscussionReplies => Set<DiscussionReply>();

        public DbSet<GradeConsultation> GradeConsultations => Set<GradeConsultation>();

        public DbSet<Notification> Notifications => Set<Notification>();

        public DbSet<Course> Courses => Set<Course>();

        public DbSet<Enrollment> Enrollments => Set<Enrollment>();

        public DbSet<Exam> Exams => Set<Exam>();

        public DbSet<ExamAnswer> ExamAnswers => Set<ExamAnswer>();

        public DbSet<ExamAttempt> ExamAttempts => Set<ExamAttempt>();

        public DbSet<ExamQuestion> ExamQuestions => Set<ExamQuestion>();
        public DbSet<Grade> Grades => Set<Grade>();

        public DbSet<Lesson> Lessons => Set<Lesson>();

        public DbSet<LessonFile> LessonFiles => Set<LessonFile>();

        public DbSet<VideoLesson> VideoLessons => Set<VideoLesson>();

        public DbSet<QuizGenerator> GenerateQuizJobs => Set<QuizGenerator>();

        public DbSet<Section> Sections => Set<Section>();

        public DbSet<UserRoles> UserRoles => Set<UserRoles>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
