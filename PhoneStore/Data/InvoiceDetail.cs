using System;
using System.Collections.Generic;

namespace PhoneStore.Data
{
    public partial class InvoiceDetail
    {
        public int InvDetailId { get; set; }
        public int? InvId { get; set; }
        public int? ProId { get; set; }
        public int? VarId { get; set; }
        public int? ProQty { get; set; }
        public double? ProPrice { get; set; }

        public virtual Invoice Inv { get; set; }
        public virtual Product Pro { get; set; }
        public virtual ProVariant Var { get; set; }
    }
}
