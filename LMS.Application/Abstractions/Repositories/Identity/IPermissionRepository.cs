using LMS.Domain.Entities.Identity.Permissions;

namespace LMS.Application.Abstractions.Repositories;

public interface IPermissionRepository
{
    Task<Permission?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task<Permission?> GetByNameAsync(
        string permissionName,
        CancellationToken cancellationToken = default);

    Task<bool> ExistsByNameAsync(
        string permissionName,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Permission>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task AddAsync(
        Permission permission,
        CancellationToken cancellationToken = default);

    void Update(Permission permission);

    void Remove(Permission permission);
}