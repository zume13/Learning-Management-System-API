using SharedKernel.Primitives;
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Identity.Permissions;

public class Permission : AggregateRoot
{
    private Permission(
        Guid id,
        string permissionName,
        string description)
        : base(id)
    {
        PermissionName = permissionName;
        Description = description;
    }

    public string PermissionName { get; private set; }

    public string Description { get; private set; }

    public static ResultT<Permission> Create(
        string permissionName,
        string description)
    {
        if (string.IsNullOrWhiteSpace(permissionName))
            return GeneralErrors.General.Empty(nameof(permissionName));

        if (string.IsNullOrWhiteSpace(description))
            return GeneralErrors.General.Empty(nameof(description));

        return new Permission(
            Guid.NewGuid(),
            permissionName,
            description);
    }

    public Result UpdatePermissionName(string permissionName)
    {
        if (string.IsNullOrWhiteSpace(permissionName))
            return GeneralErrors.General.Empty(nameof(permissionName));

        PermissionName = permissionName;

        return Result.Success();
    }

    public Result UpdateDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            return GeneralErrors.General.Empty(nameof(description));

        Description = description;

        return Result.Success();
    }
}