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

        private readonly List<Guid> _permissionIds = new();
        public IReadOnlyCollection<Guid> Permissions => _permissionIds; 

        public ResultT<Role> Create(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
                return RoleErrors.GeneralErrors.Empty(nameof(roleName));

            return new Role(Guid.NewGuid(), roleName);
        }

        public Result AssignPermission(Guid permissionId)
        {
            if (Permissions.Contains(permissionId))
                return RoleErrors.PermissionErrors.PermissionAlreadyAssigned(permissionId.ToString());

            _permissionIds.Add(permissionId);

            return Result.Success();
        }

        public Result RemovePermission(Guid permissionId)
        {
            if (!Permissions.Contains(permissionId))
                return RoleErrors.PermissionErrors.PermissionNotAssigned(permissionId.ToString());

            _permissionIds.Remove(permissionId);

            return Result.Success();
        } 

        public Result UpdateRoleName(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
                return RoleErrors.GeneralErrors.Empty(nameof(roleName));
            this.RoleName = roleName;
            return Result.Success();
        }
    }
}