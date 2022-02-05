using _247Pro.Common.DTOs.Base;
using System;

namespace _247Pro.Common.DTOs.UserAccount
{
    public class UserAccountRequest : BaseDto
    {
        public string LoginEmail { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAdress { get; set; }
        public Guid? RoleGroupId { get; set; }
    }
}
