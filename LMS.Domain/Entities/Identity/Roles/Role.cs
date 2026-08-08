using SharedKernel.Primitives;
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Identity.Roles
{
    public class Role : AggregateRoot
    {
        private Role(Guid id, string roleName) : base(id)
        {
            this.RoleName = roleName;
        }

        public string RoleName { get; private set; }

        private readonly List<Permissions> _permission = new();
        public IReadOnlyCollection<Permissions> Permissions => _permission; 

        public static ResultT<Role> Create(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
                return GeneralErrors.General.Empty(nameof(roleName));

            return new Role(Guid.NewGuid(), roleName);
        }

        public Result AssignPermission(Permissions permission)
        {
            if (Permissions.Contains(permission))
                return RoleErrors.PermissionErrors.PermissionAlreadyAssigned(nameof(permission));

            _permission.Add(permission);

            return Result.Success();
        }

        public Result RemovePermission(Permissions permission)
        {
            if (!Permissions.Contains(permission))
                return RoleErrors.PermissionErrors.PermissionNotAssigned(nameof(permission));

            _permission.Remove(permission);

            return Result.Success();
        } 

        public Result UpdateRoleName(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
                return GeneralErrors.General.Empty(nameof(roleName));
            this.RoleName = roleName;
            return Result.Success();
        }
    }
}