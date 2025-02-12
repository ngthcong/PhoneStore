﻿using System;
using System.Collections.Generic;

namespace PhoneStore.Data
{
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceDetail = new HashSet<InvoiceDetail>();
        }

        public int InvId { get; set; }
        public DateTime? InvDate { get; set; }
        public int? EmId { get; set; }
        public int? CusId { get; set; }
        public string InvCusName { get; set; }
        public string InvCusEmail { get; set; }
        public string InvCusPhone { get; set; }
        public int? InvCityId { get; set; }
        public int? InvDistrictId { get; set; }
        public int? InvWardId { get; set; }
        public string InvAddress { get; set; }
        public int? InvPaymentMethod { get; set; }
        public int? InvDeliveryMethod { get; set; }
        public string InvNote { get; set; }
        public string InvStatus { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual Account Cus { get; set; }
        public virtual Account Em { get; set; }
        public virtual AddressCity InvCity { get; set; }
        public virtual AddressDistrict InvDistrict { get; set; }
        public virtual AddressWard InvWard { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetail { get; set; }
    }
}
