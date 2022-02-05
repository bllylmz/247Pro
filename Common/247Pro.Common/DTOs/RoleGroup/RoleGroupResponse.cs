using _247Pro.Common.DTOs.Base;
using _247Pro.Common.DTOs.RoleGroupPermissionDetail;
using _247Pro.Common.DTOs.UserAccount;
using System.Collections.Generic;

namespace _247Pro.Common.DTOs.RoleGroup
{
    public class RoleGroupResponse : BaseDto
    {
        public RoleGroupResponse()
        {
            Accounts = new HashSet<UserAccountResponse>();
            RoleGroupPermissionDetails = new HashSet<RoleGroupPermissionDetailResponse>();
        }
        public string Name { get; set; }

        public ICollection<UserAccountResponse> Accounts { get; set; }
        public ICollection<RoleGroupPermissionDetailResponse> RoleGroupPermissionDetails { get; set; }
    }
}
