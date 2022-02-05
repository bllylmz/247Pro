using _247Pro.Core.Entity;
using System;

namespace _247Pro.Model.Entities
{
    public class AccountRolePermission : CoreEntity
    {
        public Guid AccountId { get; set; }
        public Guid RolePermissionId { get; set; }
        public bool Value { get; set; }

        public virtual UserAccount Account { get; set; }
        public virtual RolePermission RolePermission { get; set; }
    }
}
