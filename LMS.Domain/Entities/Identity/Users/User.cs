using LMS.Domain.ValueObjects;
using SharedKernel.Primitives;
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Identity.Users
{
    public class User : AggregateRoot
    {
        private User(Guid id, Name firstName, Name lastName, Email email, string hashedPassword)
            : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            HashedPassword = hashedPassword;
        }
        public Name FirstName { get; private set; }
        public Name LastName { get; private set; }
        public Email Email { get; private set; }
        public string HashedPassword { get; private set; }

        private readonly List<Guid> _RoleIds = new();
        public IReadOnlyCollection<Guid> RoleIds => _RoleIds;

        public readonly List<Guid> _CourseIds = new();
        public IReadOnlyCollection<Guid> CourseIds => _CourseIds;

        public ResultT<User> Create(Name firstName, Name lastName, Email email, string hashedPassword)
        {
            if (string.IsNullOrEmpty(firstName.value))
                return UserErrors.User.Empty(nameof(firstName));

            if (string.IsNullOrEmpty(lastName.value))
                return UserErrors.User.Empty(nameof(lastName));

            if (string.IsNullOrEmpty(email.value))
                return UserErrors.User.Empty(nameof(email));

            if (string.IsNullOrEmpty(hashedPassword))
                return UserErrors.User.Empty(nameof(hashedPassword));

            return new User(Guid.NewGuid(), firstName, lastName, email, hashedPassword);
        }

        public Result AssignToRole(Guid roleId)
        {
            if (RoleIds.Contains(roleId))
                return UserErrors.User.UserAlreadyInRole(roleId.ToString());

            _RoleIds.Add(roleId);

            return Result.Success();
        }

        public Result UpdateName(string firstName, string lastName)
        {
            var _firstName = Name.Create(firstName);

            if (_firstName.IsFailure)
                return _firstName.Error;

            var _lastName = Name.Create(lastName);

            if (_lastName.IsFailure)
                return _lastName.Error;

            this.FirstName = _firstName.value;
            this.LastName = _lastName.value;

            return Result.Success();
        }

        public Result UpdateEmail(string email)
        {
            var _email = Email.Create(email);

            if (_email.IsFailure)
                return _email.Error;

            this.Email = _email.value;

            return Result.Success();
        }

        public Result UpdatePassword(string hashedPassword)
        {
            if (string.IsNullOrEmpty(hashedPassword))
                return UserErrors.User.Empty(nameof(hashedPassword));

            this.HashedPassword = hashedPassword;

            return Result.Success();
        }

        public Result EnrollToCourse(Guid courseId)
        {
            if (courseId == Guid.Empty)
                return UserErrors.User.InvalidCourse;

            if (CourseIds.Contains(courseId))
                return UserErrors.User.UserAlreadyEnrolled(courseId.ToString());

            _CourseIds.Add(courseId);

            return Result.Success();
        }

        public Result UnenrollFromCourse(Guid courseId)
        {
            if (courseId == Guid.Empty)
                return UserErrors.User.InvalidCourse;

            if (!CourseIds.Contains(courseId))
                return UserErrors.User.UserNotEnrolled(courseId.ToString());

            _CourseIds.Remove(courseId);

            return Result.Success();
        }
    }
}
