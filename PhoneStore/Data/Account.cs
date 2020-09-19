using System;
using System.Collections.Generic;

namespace PhoneStore.Data
{
    public partial class Account
    {
        public Account()
        {
            AccBasket = new HashSet<AccBasket>();
            Comment = new HashSet<Comment>();
            InvoiceCus = new HashSet<Invoice>();
            InvoiceEm = new HashSet<Invoice>();
            Rating = new HashSet<Rating>();
        }

        public int AccId { get; set; }
        public string AccName { get; set; }
        public string AccEmail { get; set; }
        public string AccSalt { get; set; }
        public string AccPass { get; set; }
        public string AccPhone { get; set; }
        public DateTime? AccBirthday { get; set; }
        public int? AccCityId { get; set; }
        public int? AccDistrictId { get; set; }
        public int? AccWardId { get; set; }
        public string AccAddressNumber { get; set; }
        public string AccNote { get; set; }
        public int? AccRoleId { get; set; }
        public bool? AccStatus { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual AddressCity AccCity { get; set; }
        public virtual AddressDistrict AccDistrict { get; set; }
        public virtual AccRole AccRole { get; set; }
        public virtual AddressWard AccWard { get; set; }
        public virtual ICollection<AccBasket> AccBasket { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Invoice> InvoiceCus { get; set; }
        public virtual ICollection<Invoice> InvoiceEm { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }
    }
}
