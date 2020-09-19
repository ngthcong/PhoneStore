using System;
using System.Collections.Generic;

namespace PhoneStore.Data
{
    public partial class Rating
    {
        public int RaId { get; set; }
        public int? ProId { get; set; }
        public int? RaPoint { get; set; }
        public string RaText { get; set; }
        public DateTime? RaTime { get; set; }
        public int? RaAccId { get; set; }
        public string RaCusName { get; set; }
        public string RaCusPhone { get; set; }

        public virtual Product Pro { get; set; }
        public virtual Account RaAcc { get; set; }
    }
}
