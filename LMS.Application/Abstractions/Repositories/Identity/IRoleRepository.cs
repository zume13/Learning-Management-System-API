using LMS.Application.Abstractions.Repositories.Base;
using LMS.Domain.Entities.Identity.Roles;

namespace LMS.Application.Abstractions.Repositories;

public interface IRoleRepository : IRepository<Role>
{
    Task<Role?> GetByNameAsync(
        string roleName,
        CancellationToken cancellationToken = default);

    Task<bool> ExistsByNameAsync(
        string roleName,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Role>> GetAllRolesAsync(
        CancellationToken cancellationToken = default);
}