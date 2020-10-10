using System;
using System.Collections.Generic;

namespace PhoneStore.Data
{
    public partial class ProVariant
    {
        public ProVariant()
        {
            InvoiceDetail = new HashSet<InvoiceDetail>();
            VarImages = new HashSet<VarImages>();
        }

        public int VarId { get; set; }
        public int? ProId { get; set; }
        public string VarColor { get; set; }
        public string VarColorIcon { get; set; }
        public double? VarQty { get; set; }
        public bool? VarStatus { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual Product Pro { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetail { get; set; }
        public virtual ICollection<VarImages> VarImages { get; set; }
    }
}
