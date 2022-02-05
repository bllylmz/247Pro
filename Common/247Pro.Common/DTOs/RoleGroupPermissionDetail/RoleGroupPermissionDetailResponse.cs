using _247Pro.Common.DTOs.Base;
using _247Pro.Common.DTOs.RoleGroup;
using _247Pro.Common.DTOs.RolePermission;
using System;

namespace _247Pro.Common.DTOs.RoleGroupPermissionDetail
{
    public class RoleGroupPermissionDetailResponse : BaseDto
    {
        public Guid RoleGroupId { get; set; }
        public Guid RolePermissionId { get; set; }
        public bool Value { get; set; }

        public RoleGroupResponse RoleGroup { get; set; }
        public RolePermissionResponse RolePermission { get; set; }
    }
}
