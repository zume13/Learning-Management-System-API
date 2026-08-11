
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Sections
{
    public static class SectionErrors
    {
        public static class Section
        {
            public static Error InvalidName => Error.Failure("Section.InvalidName", "The section name is empty.");
            public static Error InvalidAcademicYear => Error.Failure("Section.InvalidAcademicYear", "The academic year is empty.");
        }
    }
}
