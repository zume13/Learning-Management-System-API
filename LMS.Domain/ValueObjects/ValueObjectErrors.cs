
using SharedKernel.Shared;

namespace LMS.Domain.ValueObjects
{
    public static class ValueObjectErrors
    {
        public static class Name
        {
            public static Error NameIsRequired => Error.Failure("Empty.Name", "Name is empty or null");   
            public static Error NameIsTooLong => Error.Validation("Name.TooLong", "Name is too long");
        }

        public static class Email
        {
            public static Error EmailIsRequired => Error.Failure("Empty.Email", "Email is empty or null");
            public static Error InvalidEmailFormat => Error.Validation("Email.InvalidFormat", "Email format is invalid");
        }
    }
}
