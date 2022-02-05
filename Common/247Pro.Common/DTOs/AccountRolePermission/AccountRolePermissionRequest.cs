using _247Pro.Common.DTOs.Base;
using System;

namespace _247Pro.Common.DTOs.AccountRolePermission
{
    public class AccountRolePermissionRequest : BaseDto
    {
        public Guid AccountId { get; set; }
        public Guid RolePermissionId { get; set; }
        public bool Value { get; set; }
    }
}
