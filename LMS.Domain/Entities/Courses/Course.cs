using SharedKernel.Primitives;
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Courses
{
    public class Course : AggregateRoot
    {
        private Course(
            Guid id,
            string courseCode,
            string courseName,
            string courseDescription,
            string invitationCode,
            int courseUnits,
            Guid instructorId) 
            : base(id)
        {
            CourseCode = courseCode;
            CourseName = courseName;
            CourseDescription = courseDescription;
            InvitationCode = invitationCode;
            CourseUnits = courseUnits;
            InstructorId = instructorId;
            Status = CourseStatus.Ongoing;
            CreatedAt = DateTime.UtcNow;
        }

        public string CourseCode { get; private set; }
        public string CourseName { get; private set; }
        public string CourseDescription { get; private set; }
        public string InvitationCode { get; private set; }

        public int CourseUnits { get; private set; }

        public Guid InstructorId { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public CourseStatus Status { get; private set; } 

        public ResultT<Course> Create(
            string courseCode,
            string courseName,
            string courseDescription,
            string invitationCode,
            int courseUnits,
            Guid instructorId)
        {
            if (string.IsNullOrWhiteSpace(courseCode))
                return CourseErrors.Course.Empty(nameof(courseCode));

            if (string.IsNullOrWhiteSpace(courseName))
                return CourseErrors.Course.Empty(nameof(courseName));

            if (string.IsNullOrWhiteSpace(courseDescription))
                return CourseErrors.Course.Empty(nameof(courseDescription));

            if (courseUnits <= 0)
                return CourseErrors.Course.InvalidUnits();

            if (instructorId == Guid.Empty)
                return CourseErrors.Course.InvalidInstructor();

            return new Course(
                Guid.NewGuid(),
                courseCode,
                courseName,
                courseDescription,
                invitationCode,
                courseUnits,
                instructorId);
        }
        public Result Archive()
        {
            if (Status == CourseStatus.Archived)
                return CourseErrors.Course.CourseAlreadyArchived();

            Status = CourseStatus.Archived;
            UpdatedAt = DateTime.UtcNow;

            return Result.Success();
        }   

    }
}
