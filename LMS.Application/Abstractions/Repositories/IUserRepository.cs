
using LMS.Domain.Entities.Identity.Users;
using LMS.Domain.ValueObjects;
using SharedKernel.Shared;

namespace LMS.Application.Abstractions.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<ResultT<User>> GetByEmailAsync(Email email, CancellationToken cancellationToken = default);
    }
}
