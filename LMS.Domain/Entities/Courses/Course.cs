
using SharedKernel.Primitives;
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Courses
{
    public class Course : AggregateRoot
    {
        public Course(
            Guid id,
            string courseCode,
            string courseName,
            string courseDescription,
            int courseUnits,
            int maxStudents,
            Guid instructorId) 
            : base(id)
        {
            CourseCode = courseCode;
            CourseName = courseName;
            CourseDescription = courseDescription;
            CourseUnits = courseUnits;
            MaxStudents = maxStudents;
            InstructorId = instructorId;

            CreatedAt = DateTime.UtcNow;
        }

        public string CourseCode { get; private set; }
        public string CourseName { get; private set; }
        public string CourseDescription { get; private set; }

        public int CourseUnits { get; private set; }
        public int MaxStudents { get; private set; }

        public Guid InstructorId { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public ResultT<Course> Create(
            string courseCode,
            string courseName,
            string courseDescription,
            int courseUnits,
            int maxStudents,
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

            if (maxStudents <= 0)
                return CourseErrors.Course.InvalidMaxStudents();

            if (instructorId == Guid.Empty)
                return CourseErrors.Course.InvalidInstructor();

            return new Course(
                Guid.NewGuid(),
                courseCode,
                courseName,
                courseDescription,
                courseUnits,
                maxStudents,
                instructorId);
        }
    }
}
