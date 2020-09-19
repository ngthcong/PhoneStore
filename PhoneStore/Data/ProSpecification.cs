using System;
using System.Collections.Generic;

namespace PhoneStore.Data
{
    public partial class ProSpecification
    {
        public long Id { get; set; }
        public int? ProId { get; set; }
        public int? SpecId { get; set; }
        public string SpecValue { get; set; }

        public virtual Product Pro { get; set; }
        public virtual Specification Spec { get; set; }
    }
}
