using _247Pro.Common.DTOs.Base;
using _247Pro.Common.DTOs.EstimatesAccounts;
using System.Collections.Generic;

namespace _247Pro.Common.DTOs.Estimate
{
    public class EstimateResponse : BaseDto
    {
        public EstimateResponse()
        {
            EstimatesAccounts = new HashSet<EstimatesAccountsResponse>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }

        public virtual ICollection<EstimatesAccountsResponse> EstimatesAccounts { get; set; }
    }
}
