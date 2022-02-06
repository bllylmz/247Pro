using _247Pro.Core.Entity;
using System;
using System.Collections.Generic;

namespace _247Pro.Model.Entities
{
    public class UserAccount : CoreEntity
    {
        public UserAccount()
        {
            AccountRolePermissions = new HashSet<AccountRolePermission>();
            EstimatesAccounts = new HashSet<EstimatesAccounts>();
            SubAccounts = new HashSet<UserAccount>();
        }
        public string LoginEmail { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAdress { get; set; }
        public Guid? RoleGroupId { get; set; }
        public Guid? SubAccountId { get; set; }
        public string LastIPAdress { get; set; }
        public DateTime? LastLogin { get; set; }


        public RoleGroup RoleGroup { get; set; }
        public UserAccount SubAccount { get; set; }
        public virtual ICollection<AccountRolePermission> AccountRolePermissions { get; set; }
        public virtual ICollection<EstimatesAccounts> EstimatesAccounts { get; set; }
        public virtual ICollection<UserAccount> SubAccounts { get; set; }
    }
}
