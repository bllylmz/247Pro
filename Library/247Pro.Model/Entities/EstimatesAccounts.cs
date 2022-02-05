using System;

namespace _247Pro.Model.Entities
{
    public class EstimatesAccounts
    {
        public Guid EstimateId { get; set; }
        public Guid AccountId { get; set; }

        public virtual UserAccount Account { get; set; }
        public virtual Estimate Estimate { get; set; }
    }
}
