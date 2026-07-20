using LMS.Domain.ValueObjects;
using LMS.SharedKernel.Primitives;
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
        private Name FirstName { get; set; }
        private Name LastName { get; set; }
        private Email Email { get; set; }
        private string HashedPassword { get; set; }

        //Collections of roles
        private readonly List<Guid> _RoleIds = new();
        public IReadOnlyCollection<Guid> RoleIds => _RoleIds;

        public ResultT<User> Create(Name firstName, Name lastName, Email email, string hashedPassword)
        {
            if(string.IsNullOrEmpty(firstName.value))
                return UserErrors.User.Empty(nameof(firstName));

            if(string.IsNullOrEmpty(lastName.value))
                return UserErrors.User.Empty(nameof(lastName));
            
            if(string.IsNullOrEmpty(email.value))
                return UserErrors.User.Empty(nameof(email));

            if(string.IsNullOrEmpty(hashedPassword))
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

        public ResultT<User> UpdateName(Name firstName, Name lastName)
        {
            if (string.IsNullOrEmpty(firstName.value))
                return UserErrors.User.Empty(nameof(firstName));
            if (string.IsNullOrEmpty(lastName.value))
                return UserErrors.User.Empty(nameof(lastName));

            this.FirstName = firstName;
            this.LastName = lastName;

            return this;
        }

        public ResultT<User> UpdateEmail(Email email)
        {
            if (string.IsNullOrEmpty(email.value))
                return UserErrors.User.Empty(nameof(email));
            this.Email = email;

            return this;
        }
    }
}
