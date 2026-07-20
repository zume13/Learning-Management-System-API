using LMS.Domain.ValueObjects;
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Identity.Users
{
    public class User
    {
        private User(Name firstName, Name lastName, Email email, string hashedPassword)
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

            return new User(firstName, lastName, email, hashedPassword);
        }
    }
}
