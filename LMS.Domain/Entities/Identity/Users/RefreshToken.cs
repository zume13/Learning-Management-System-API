using LMS.SharedKernel.Primitives;
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Identity.Users
{
    public class RefreshToken : Entity
    {
        private RefreshToken(Guid id, string tokenHash, Guid userId, DateTime expiryDate, DateTime createDate)
             : base(id)
        {
            TokenHash = tokenHash;
            UserId = userId;
            ExpiryDate = expiryDate;
            CreateDate = createDate;
        }

        public string TokenHash { get; private set; }

        public Guid UserId { get; private set; }

        public DateTime ExpiryDate { get; private set; }

        public DateTime CreateDate { get; private set; }

        public bool IsRevoked { get; private set; }

        public DateTime? RevokedDate { get; private set; }

        public Guid? ReplacedByTokenID { get; private set; }

        public static ResultT<RefreshToken> Create(Guid userId, string tokenHash, DateTime expiryDate, DateTime createDate)
        {
            if (string.IsNullOrWhiteSpace(tokenHash))
                return GeneralErrors.General.Empty(nameof(tokenHash));

            if (expiryDate <= DateTime.UtcNow)
                return UserErrors.RefreshToken.ExpiredToken;

            return new RefreshToken(Guid.NewGuid(), tokenHash, userId, expiryDate, createDate);
        }

        public Result Revoke(Guid? replacedByTokenID = null)
        {
            if (IsRevoked)
                return UserErrors.RefreshToken.RevokedToken;

            IsRevoked = true;
            RevokedDate = DateTime.UtcNow;
            ReplacedByTokenID = replacedByTokenID;

            return Result.Success();
        }

        public bool IsExpired => DateTime.UtcNow >= ExpiryDate;

        public bool IsActive => !IsRevoked && !IsExpired;
    }
}
