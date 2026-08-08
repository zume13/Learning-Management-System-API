using LMS.Application.Abstractions.Repositories.Base;
using LMS.Domain.Entities.Identity.Users;

namespace LMS.Application.Abstractions.Repositories.Identity;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(
        string email,
        CancellationToken cancellationToken = default);

    Task<bool> EmailExistsAsync(
        string email,
        CancellationToken cancellationToken = default);
}