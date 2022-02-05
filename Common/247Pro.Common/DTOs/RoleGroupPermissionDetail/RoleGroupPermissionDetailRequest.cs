using _247Pro.Common.DTOs.Base;
using System;

namespace _247Pro.Common.DTOs.RoleGroupPermissionDetail
{
    public class RoleGroupPermissionDetailRequest : BaseDto
    {
        public Guid RoleGroupId { get; set; }
        public Guid RolePermissionId { get; set; }
        public bool Value { get; set; }
    }
}
