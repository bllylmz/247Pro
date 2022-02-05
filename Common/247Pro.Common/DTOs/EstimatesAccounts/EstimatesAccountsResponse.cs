using _247Pro.Common.DTOs.Estimate;
using _247Pro.Common.DTOs.UserAccount;
using System;

namespace _247Pro.Common.DTOs.EstimatesAccounts
{
    public class EstimatesAccountsResponse
    {
        public Guid EstimateId { get; set; }
        public Guid AccountId { get; set; }

        public virtual UserAccountResponse Account { get; set; }
        public virtual EstimateResponse Estimate { get; set; }
    }
}
