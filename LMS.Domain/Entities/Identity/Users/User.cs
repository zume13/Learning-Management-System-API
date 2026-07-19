
using LMS.Domain.ValueObjects;

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

        public User Create(Name firstName, Name lastName, Email email, string hashedPassword)
        {
            return new User(firstName, lastName, email, hashedPassword);
        }

        public User Update(string firstName, string lastName)
        {
            throw new NotImplementedException();
        }
    }
}
