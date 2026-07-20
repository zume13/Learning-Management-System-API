using LMS.SharedKernel.Primitives;
using SharedKernel.Shared;

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
            CreateDate = DateTime.UtcNow;
        }

        public string TokenHash { get; private set; }

        public Guid UserId { get; private set; }

        public DateTime ExpiryDate { get; private set; }

        public DateTime CreateDate { get; private set; }

        public bool IsRevoked { get; private set; }

        public DateTime? RevokedDate { get; private set; }

        public Guid? ReplacedByTokenID { get; private set; }


        private RefreshToken() { }

        public static ResultT<RefreshToken> Create(Guid userId, string tokenHash, DateTime expiryDate, DateTime createDate)
        {
            if (string.IsNullOrWhiteSpace(tokenHash))
                return RefreshTokenError.EmptyToken;


            if (expiryDate <= DateTime.UtcNow)
                return RefreshTokenError.ExpiredToken;

            return new RefreshToken(Guid.NewGuid(), tokenHash, userId, expiryDate);
        }

        public Result Revoke(Guid? replacedByTokenID = null)
        {
            if (IsRevoked)
                return RefreshTokenError.RevokedToken;

            IsRevoked = true;
            RevokedDate = DateTime.UtcNow;
            ReplacedByTokenID = replacedByTokenID;

            return Result.Success();
        }

        public bool IsExpired => DateTime.UtcNow >= ExpiryDate;

        public bool IsActive => !IsRevoked && !IsExpired;
    }
}
