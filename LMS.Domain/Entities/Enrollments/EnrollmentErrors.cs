
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Enrollments
{
    public static class EnrollmentErrors
    {
        public static class Enrollment
        {
            public static Error InvalidStudent => Error.Failure("Enrollment.InvalidStudent", "The student id is empty.");
            public static Error InvalidCourse => Error.Failure("Enrollment.InvalidCourse", "The course id is empty.");
            public static Error InvalidSection => Error.Failure("Enrollment.InvalidSection", "The section id is empty.");
        }
    }
}
