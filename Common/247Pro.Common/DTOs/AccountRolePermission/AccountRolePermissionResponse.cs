using _247Pro.Common.DTOs.Base;
using _247Pro.Common.DTOs.RolePermission;
using _247Pro.Common.DTOs.UserAccount;
using System;

namespace _247Pro.Common.DTOs.AccountRolePermission
{
    public class AccountRolePermissionResponse : BaseDto
    {
        public Guid AccountId { get; set; }
        public Guid RolePermissionId { get; set; }
        public bool Value { get; set; }

        public virtual UserAccountResponse Account { get; set; }
        public virtual RolePermissionResponse RolePermission { get; set; }
    }
}
