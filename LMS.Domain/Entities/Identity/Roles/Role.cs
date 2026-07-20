using LMS.SharedKernel.Primitives;
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Identity.Roles
{
    public class Role : Entity
    {
        public Role(Guid id, string roleName) : base(id)
        {
            this.RoleName = roleName;
        }

        private string RoleName { get; set; }

        private readonly List<Guid> PermissionIds = new();
        public IReadOnlyCollection<Guid> Permissions => PermissionIds; 

        public ResultT<Role> Create(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
                

            return new Role(Guid.NewGuid(), roleName);
        }
    }
}