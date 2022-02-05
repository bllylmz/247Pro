using _247Pro.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace _247Pro.Model.Entities
{
    public class RoleGroup : CoreEntity
    {
        public RoleGroup()
        {
            Accounts = new HashSet<UserAccount>();
            RoleGroupPermissionDetails = new HashSet<RoleGroupPermissionDetail>();
        }

        public string Name { get; set; }

        public virtual ICollection<UserAccount> Accounts { get; set; }
        public virtual ICollection<RoleGroupPermissionDetail> RoleGroupPermissionDetails { get; set; }
    }
}
