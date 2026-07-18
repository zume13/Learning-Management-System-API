
using LMS.Domain.ValueObjects;

namespace LMS.Domain.Entities.Identity.Users
{
    public class User
    {
        private User(string firstName, string lastName, Guid refreshTokenId)
        {
            FirstName = firstName;
            LastName = lastName;
            RefreshTokenId = refreshTokenId;
        }
        private Name FirstName { get; set; }
        private Name LastName { get; set; }
        private Guid RefreshTokenId { get; set; }
        private Email Email { get; set; }
        private string HashedPassword { get; set; }

        public User Create(string firstName, string lastName)
        {
            var refreshToken = new RefreshToken();
            var refreshTokenId = Guid.NewGuid();

            return new User(firstName, lastName, refreshTokenId);
        }

        public User Update(string firstName, string lastName)
        {
           
        }
    }
}
