using System;
using System.Collections.Generic;

namespace PhoneStore.Data
{
    public partial class Account
    {
        public Account()
        {
            InvoiceCus = new HashSet<Invoice>();
            InvoiceEm = new HashSet<Invoice>();
        }

        public int AccId { get; set; }
        public string AccName { get; set; }
        public string AccEmail { get; set; }
        public string AccSalt { get; set; }
        public string AccPass { get; set; }
        public string AccPhone { get; set; }
        public int? AccWardId { get; set; }
        public string AccAddress { get; set; }
        public string AccNote { get; set; }
        public int? AccRoleId { get; set; }
        public bool? AccStatus { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual AccRole AccRole { get; set; }
        public virtual AddressWard AccWard { get; set; }
        public virtual ICollection<Invoice> InvoiceCus { get; set; }
        public virtual ICollection<Invoice> InvoiceEm { get; set; }
    }
}
