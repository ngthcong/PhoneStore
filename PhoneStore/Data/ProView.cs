using System;
using System.Collections.Generic;

namespace PhoneStore.Data
{
    public partial class ProView
    {
        public string Id { get; set; }
        public int? ProId { get; set; }
        public DateTime? DateViewed { get; set; }
        public string IpAddress { get; set; }

        public virtual Product Pro { get; set; }
    }
}
