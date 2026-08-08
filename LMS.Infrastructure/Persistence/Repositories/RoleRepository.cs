using LMS.Application.Abstractions.Repositories;
using LMS.Infrastructure.Persistence.Database;
using LMS.Infrastructure.Persistence.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Persistence.Repositories;

public sealed class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(ApplicationDbContext context) : base(context) { }

    public async Task<Role?> GetByNameAsync(
        string roleName,
        CancellationToken cancellationToken = default)
    {
        var role = await _dbContext.Roles
            .FirstOrDefaultAsync(
                x => x.RoleName == roleName,
                cancellationToken);

        if (role is null)
            return null;

        var permissionIds = await _dbContext.RolePermissions
            .Where(x => x.RoleId == role.Id)
            .Select(x => x.PermissionId)
            .ToListAsync(cancellationToken);

        role.LoadPermissionIds(permissionIds);

        return role;
    }

    public Task<bool> ExistsByNameAsync(
        string roleName,
        CancellationToken cancellationToken = default)
    {
        return _dbContext.Roles
            .AnyAsync(
                x => x.RoleName == roleName,
                cancellationToken);
    }

    public async Task<IReadOnlyList<Role>> GetAllRolesAsync(
        CancellationToken cancellationToken = default)
    {
        var roles = await _dbContext.Roles
            .ToListAsync(cancellationToken);

        var roleIds = roles
            .Select(x => x.Id)
            .ToList();

        var permissions = await _dbContext.RolePermissions
            .Where(x => roleIds.Contains(x.RoleId))
            .ToListAsync(cancellationToken);

        foreach (var role in roles)
        {
            var permissionIds = permissions
                .Where(x => x.RoleId == role.Id)
                .Select(x => x.PermissionId);

            role.LoadPermissionIds(permissionIds);
        }

        return roles;
    }

    public override void Update(Role role)
    {
        _dbContext.Roles.Update(role);

        SyncPermissions(role);
    }
    private void SyncPermissions(Role role)
    {
        var existingPermissions = _dbContext.RolePermissions
            .Where(x => x.RoleId == role.Id)
            .ToList();

        var desiredPermissionIds =
            role.PermissionIds.ToHashSet();

        var permissionsToRemove = existingPermissions
            .Where(x => !desiredPermissionIds.Contains(x.PermissionId))
            .ToList();

        _dbContext.RolePermissions.RemoveRange(
            permissionsToRemove);

        var existingPermissionIds = existingPermissions
            .Select(x => x.PermissionId)
            .ToHashSet();

        var permissionsToAdd = desiredPermissionIds
            .Where(x => !existingPermissionIds.Contains(x))
            .Select(permissionId => new RolePermission
            {
                RoleId = role.Id,
                PermissionId = permissionId
            });

        _dbContext.RolePermissions.AddRange(
            permissionsToAdd);
    }
}