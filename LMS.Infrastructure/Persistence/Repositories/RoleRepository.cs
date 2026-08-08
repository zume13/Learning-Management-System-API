using LMS.Application.Abstractions.Repositories;
using LMS.Domain.Entities.Identity.Roles;
using LMS.Infrastructure.Persistence.Database;
using LMS.Infrastructure.Persistence.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Persistence.Repositories;

internal sealed class RoleRepository : IRoleRepository
{
    private readonly ApplicationDbContext _context;

    public RoleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Role?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var role = await _context.Roles
            .FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);

        if (role is null)
            return null;

        var permissionIds = await _context.RolePermissions
            .Where(x => x.RoleId == id)
            .Select(x => x.PermissionId)
            .ToListAsync(cancellationToken);

        role.LoadPermissionIds(permissionIds);

        return role;
    }

    public async Task<Role?> GetByNameAsync(
        string roleName,
        CancellationToken cancellationToken = default)
    {
        var role = await _context.Roles
            .FirstOrDefaultAsync(
                x => x.RoleName == roleName,
                cancellationToken);

        if (role is null)
            return null;

        var permissionIds = await _context.RolePermissions
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
        return _context.Roles
            .AnyAsync(
                x => x.RoleName == roleName,
                cancellationToken);
    }

    public async Task<IReadOnlyList<Role>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var roles = await _context.Roles
            .ToListAsync(cancellationToken);

        var roleIds = roles
            .Select(x => x.Id)
            .ToList();

        var permissions = await _context.RolePermissions
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

    public async Task AddAsync(
        Role role,
        CancellationToken cancellationToken = default)
    {
        await _context.Roles.AddAsync(
            role,
            cancellationToken);

        foreach (var permissionId in role.PermissionIds)
        {
            await _context.RolePermissions.AddAsync(
                new RolePermission
                {
                    RoleId = role.Id,
                    PermissionId = permissionId
                },
                cancellationToken);
        }
    }

    public void Update(Role role)
    {
        _context.Roles.Update(role);

        SyncPermissions(role);
    }

    public void Remove(Role role)
    {
        _context.Roles.Remove(role);
    }

    private void SyncPermissions(Role role)
    {
        var existingPermissions = _context.RolePermissions
            .Where(x => x.RoleId == role.Id)
            .ToList();

        var desiredPermissionIds =
            role.PermissionIds.ToHashSet();

        var permissionsToRemove = existingPermissions
            .Where(x => !desiredPermissionIds.Contains(x.PermissionId))
            .ToList();

        _context.RolePermissions.RemoveRange(
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

        _context.RolePermissions.AddRange(
            permissionsToAdd);
    }
}