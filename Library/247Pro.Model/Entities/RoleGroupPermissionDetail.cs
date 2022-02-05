using _247Pro.Core.Entity;
using System;

namespace _247Pro.Model.Entities
{
    public class RoleGroupPermissionDetail : CoreEntity
    {
        public Guid RoleGroupId { get; set; }
        public Guid RolePermissionId { get; set; }
        public bool Value { get; set; }

        public virtual RoleGroup RoleGroup { get; set; }
        public virtual RolePermission RolePermission { get; set; }
    }
}
