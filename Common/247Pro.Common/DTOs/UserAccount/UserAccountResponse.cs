using _247Pro.Common.DTOs.Base;
using _247Pro.Common.Models;
using System;

namespace _247Pro.Common.DTOs.UserAccount
{
    public class UserAccountResponse : BaseDto
    {
        public string LoginEmail { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAdress { get; set; }
        public Guid RoleGroupId { get; set; }
        public string LastIPAdress { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? CreatedDate { get; set; }
        public GetAccessToken AccessToken { get; set; }
    }
}
