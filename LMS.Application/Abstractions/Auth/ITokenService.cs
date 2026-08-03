using LMS.Domain.Entities.Identity.Users;
using SharedKernel.Shared;


namespace LMS.Application.Abstractions.Auth
{
    public interface ITokenService
    {
        Task<ResultT<string?>> GenerateAccessToken(User user);
    }
}
