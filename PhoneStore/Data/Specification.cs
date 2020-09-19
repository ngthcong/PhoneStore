using System;
using System.Collections.Generic;

namespace PhoneStore.Data
{
    public partial class Specification
    {
        public Specification()
        {
            ProSpecification = new HashSet<ProSpecification>();
        }

        public int SpecId { get; set; }
        public string SpecName { get; set; }

        public virtual ICollection<ProSpecification> ProSpecification { get; set; }
    }
}
