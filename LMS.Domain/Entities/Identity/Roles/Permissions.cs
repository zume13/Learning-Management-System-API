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
        private string PermissionName { get; set; }
        private string Description { get; set; }

        public ResultT<Permissions> Create(string permissionName, string description)
        {
            if (string.IsNullOrEmpty(permissionName))
                return PermissionsError.EmptyPermissionName;
            if (string.IsNullOrEmpty(description))
                return PermissionsError.EmptyDescription;

            return new Permissions(Guid.NewGuid(), permissionName, description);
        }   
    }
}