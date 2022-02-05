using System;

namespace _247Pro.Common.DTOs.EstimatesAccounts
{
    public class EstimatesAccountsRequest
    {
        public Guid EstimateId { get; set; }
        public Guid AccountId { get; set; }
    }
}
