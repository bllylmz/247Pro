using _247Pro.Core.Entity;
using System.Collections.Generic;

namespace _247Pro.Model.Entities
{
    public class Estimate : CoreEntity
    {
        public Estimate()
        {
            EstimatesAccounts = new HashSet<EstimatesAccounts>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }

        public virtual ICollection<EstimatesAccounts> EstimatesAccounts { get; set; }
    }
}
