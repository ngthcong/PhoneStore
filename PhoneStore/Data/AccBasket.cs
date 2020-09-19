using System;
using System.Collections.Generic;

namespace PhoneStore.Data
{
    public partial class AccBasket
    {
        public long BasketId { get; set; }
        public int? AccId { get; set; }
        public int? VarId { get; set; }
        public int? ProId { get; set; }
        public int? Qty { get; set; }

        public virtual Account Acc { get; set; }
        public virtual Product Pro { get; set; }
        public virtual ProVariant Var { get; set; }
    }
}
