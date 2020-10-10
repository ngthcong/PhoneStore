using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Models.FormModel
{
    public class CheckOutModel
    {
        public int? CusId { get; set; }
        public string InvCusName { get; set; }
        public string InvCusPhone { get; set; }
        public string InvCusEmail { get; set; }
        public int? InvWardId { get; set; }
        public string InvAddress { get; set; }
        public int? InvPaymentMethod { get; set; }
        public int? InvDeliveryMethod { get; set; }
    }
}
