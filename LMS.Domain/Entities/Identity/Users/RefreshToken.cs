using LeaveManagement.SharedKernel.Primitives;

namespace LMS.Domain.Entities.Identity.Users
{
    public class RefreshToken : Entity
    {
       public RefreshToken(Guid id, string tokenHash, Guid userId, DateTime expiryDate)
            : base(id)
        {
            TokenHash = tokenHash;
            UserId = userId;
            ExpiryDate = expiryDate;
        }


        public string TokenHash { get; private set; }

        public Guid UserId { get; private set; }

        public DateTime ExpiryDate { get; private set; }

        public DateTime CreateDate { get; private set; }

        public bool IsRevoked { get; private set; }

        public DateTime? RevokedDate { get; private set; }

        public Guid? ReplacedByTokenId { get; private set; }

    }
}
