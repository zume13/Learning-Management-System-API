namespace LMS.Infrastructure.Persistence.Database.Entities;

public class RolePermission
{
    public Guid RoleId { get; set; }
    public Guid PermissionId { get; set; }
}