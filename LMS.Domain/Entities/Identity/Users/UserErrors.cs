using SharedKernel.Shared;

namespace LMS.Domain.Entities.Identity.Users
{
    public class UserErrors
    {
        public static class User
        {
            public static Error Empty(string errorName) => Error.Failure($"{errorName}.Empty", $"{errorName} cannot be empty.");
            public static Error UserAlreadyInRole(string roleId) => Error.Failure("User.AlreadyInRole", $"User is already assigned to the role '{roleId}'.");
            public static Error UserAlreadyEnrolled(string courseId) => Error.Failure("User.AlreadyEnrolled", $"User is already enrolled in the course '{courseId}'.");
            public static Error InvalidCourse => Error.Failure("User.InvalidCourse", "The course id is empty.");
            public static Error UserNotEnrolled(string courseId) => Error.Failure("User.StudentNotEnrolled", $"Student is not enrolled in course '{courseId}'.");
        }

        public static class RefreshToken
        {
            public static Error EmptyToken => Error.Failure("RefreshToken.EmptyToken", "Refresh token cannot be empty.");
            public static Error ExpiredToken => Error.Failure("RefreshToken.ExpiredToken", "Refresh token has expired.");
            public static Error RevokedToken => Error.Failure("RefreshToken.RevokedToken", "Refresh token has been revoked.");
        }
    }
}
