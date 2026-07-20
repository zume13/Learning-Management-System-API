using LMS.SharedKernel.Primitives;
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Identity.Roles
{
    public class Permissions : Entity
    {
        public Permissions(Guid id, string permissionName, string description) : base(id)
        {
            this.PermissionName = permissionName;
            this.Description = description;
        }
        public string PermissionName { get; private set; }
        public string Description { get; private set; }

        public ResultT<Permissions> Create(string permissionName, string description)
        {
            if (string.IsNullOrEmpty(permissionName))
                return RoleErrors.GeneralErrors.Empty(nameof(permissionName));

            if (string.IsNullOrEmpty(description))
                return RoleErrors.GeneralErrors.Empty(nameof(description));

            return new Permissions(Guid.NewGuid(), permissionName, description);
        }   

        public Result UpdatePermissionName(string permissionName)
        {
            if (string.IsNullOrEmpty(permissionName))
                return RoleErrors.GeneralErrors.Empty(nameof(permissionName));

            this.PermissionName = permissionName;

            return Result.Success();
        }

        public Result UpdateDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
                return RoleErrors.GeneralErrors.Empty(nameof(description));

            this.Description = description;

            return Result.Success();
        }
    }
}