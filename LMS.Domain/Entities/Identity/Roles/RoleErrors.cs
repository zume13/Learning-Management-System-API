
using SharedKernel.Shared;
using System.Data;

namespace LMS.Domain.Entities.Identity.Roles
{
    public static class RoleErrors
    {
        public static class GeneralErrors 
        {
            public static Error Empty(string errorName) => Error.Failure($"{errorName}.Empty", $"{errorName} cannot be empty.");
        }

        public static class PermissionErrors
        {
            public static Error PermissionAlreadyAssigned(string permissionId) => Error.Failure("Permission.AlreadyAssigned", $"Permission '{permissionId}' is already assigned to the role.");
            public static Error PermissionNotAssigned(string permissionId) => Error.Failure("Permission.NotAssigned", $"Permission '{permissionId}' is not assigned to the role.");
        }

        public static class RolesErrors 
        {
        }

    }
}
