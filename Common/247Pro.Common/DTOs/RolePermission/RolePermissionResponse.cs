using _247Pro.Common.DTOs.Base;

namespace _247Pro.Common.DTOs.RolePermission
{
    public class RolePermissionResponse : BaseDto
    {
        public string Code { get; set; }
        public bool Value { get; set; }
        public string Group { get; set; }
    }
}
