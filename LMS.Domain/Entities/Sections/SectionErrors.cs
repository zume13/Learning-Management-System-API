
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Sections
{
    public static class SectionErrors
    {
        public static class Section
        {
            public static Error InvalidName => Error.Failure("Section.InvalidName", "The section name is empty.");
            public static Error InvalidCourse => Error.Failure("Section.InvalidCourse", "The course id is empty.");
        }
    }
}
