
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Grades
{
    public static class GradeErrors
    {
        public static class Grade
        {
            public static Error InvalidScore => Error.Failure("Grade.Invalid", "Grade cannot be lower than 0");
            public static Error Locked => Error.Failure("Grade.Locked", "Grade is locked");
        }
    }
}
