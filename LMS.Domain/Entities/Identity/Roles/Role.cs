using LMS.Domain.Entities.Identity.Roles;
using SharedKernel.Primitives;
using SharedKernel.Shared;

public class Role : AggregateRoot
{
    private Role(Guid id, string roleName)
        : base(id)
    {
        RoleName = roleName;
    }

    public string RoleName { get; private set; }

    private readonly List<Guid> _permissionIds = new();

    public IReadOnlyCollection<Guid> PermissionIds =>
        _permissionIds.AsReadOnly();

    public static ResultT<Role> Create(string roleName)
    {
        if (string.IsNullOrWhiteSpace(roleName))
            return GeneralErrors.General.Empty(nameof(roleName));

        return new Role(Guid.NewGuid(), roleName);
    }

    public Result AssignPermission(Guid permissionId)
    {
        if (_permissionIds.Contains(permissionId))
        {
            return PermissionErrors.PermissionError
                .PermissionAlreadyAssigned(nameof(permissionId));
        }

        _permissionIds.Add(permissionId);

        return Result.Success();
    }

    public Result RemovePermission(Guid permissionId)
    {
        if (!_permissionIds.Contains(permissionId))
        {
            return PermissionErrors.PermissionError
                .PermissionNotAssigned(nameof(permissionId));
        }

        _permissionIds.Remove(permissionId);

        return Result.Success();
    }

    public Result UpdateRoleName(string roleName)
    {
        if (string.IsNullOrWhiteSpace(roleName))
            return GeneralErrors.General.Empty(nameof(roleName));

        RoleName = roleName;

        return Result.Success();
    }

    public void LoadPermissionIds(
        IEnumerable<Guid> permissionIds)
    {
        _permissionIds.Clear();
        _permissionIds.AddRange(permissionIds);
    }
}