using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Models.ViewModel.Cart
{
    public class AdminInvoiceModel
    {
        public int InvId { get; set; }
        public DateTime? InvDate { get; set; }
        public int? EmId { get; set; }
        public int? CusId { get; set; }
        public string InvCusName { get; set; }
        public string InvCusEmail { get; set; }
        public string InvCusPhone { get; set; }

        public string InvAddress { get; set; }
        public string InvNote { get; set; }
        public bool? InvStatus { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? ProductCount { get; set; }
        public double? Total { get; set; }
    }
}
