using System;
using System.Collections.Generic;

namespace PhoneStore.Data
{
    public partial class Promotion
    {
        public int Id { get; set; }
        public DateTime? TimeStart { get; set; }
        public DateTime? TimeEnd { get; set; }
        public double? PromValue { get; set; }
        public bool? PromStatus { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
