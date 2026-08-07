
using SharedKernel.Shared;
using System.Data;

namespace LMS.Domain.Entities.Identity.Roles
{
    public static class RoleErrors
    {
        public static class PermissionErrors
        {
            public static Error PermissionAlreadyAssigned(string permission) => Error.Failure("Permission.AlreadyAssigned", $"Permission '{permission}' is already assigned to the role.");
            public static Error PermissionNotAssigned(string permission) => Error.Failure("Permission.NotAssigned", $"Permission '{permission}' is not assigned to the role.");
        }

        public static class RolesErrors 
        {
        }

    }
}
