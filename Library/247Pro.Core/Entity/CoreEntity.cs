using System;

namespace _247Pro.Core.Entity
{
    public class CoreEntity : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public string CreatedIP { get; set; }
        public DateTime? CreatedDate { get; set; }

        public string ModifiedIP { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
