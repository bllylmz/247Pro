using _247Pro.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace _247Pro.Model.Entities
{
    public class RolePermission : CoreEntity
    {
        public RolePermission()
        {
            AccountRolePermissions = new HashSet<AccountRolePermission>();
            RoleGroupPermissionDetails = new HashSet<RoleGroupPermissionDetail>();
        }

        public string Code { get; set; }
        public bool Value { get; set; }
        public string Group { get; set; }

        public virtual ICollection<AccountRolePermission> AccountRolePermissions { get; set; }
        public virtual ICollection<RoleGroupPermissionDetail> RoleGroupPermissionDetails { get; set; }
    }
}
