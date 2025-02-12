﻿using System;
using System.Collections.Generic;

namespace PhoneStore.Data
{
    public partial class Product
    {
        public Product()
        {
            AccBasket = new HashSet<AccBasket>();
            Comment = new HashSet<Comment>();
            InvoiceDetail = new HashSet<InvoiceDetail>();
            ProSpecification = new HashSet<ProSpecification>();
            ProVariant = new HashSet<ProVariant>();
            ProView = new HashSet<ProView>();
            Rating = new HashSet<Rating>();
        }

        public int ProId { get; set; }
        public string ProName { get; set; }
        public string ProImage { get; set; }
        public int? ProGroupId { get; set; }
        public int? ProBrandId { get; set; }
        public int? ProTypeId { get; set; }
        public double? ProRetailPrice { get; set; }
        public double? ProSalePrice { get; set; }
        public string ProDescription { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool? ProStatus { get; set; }

        public virtual ProBrand ProBrand { get; set; }
        public virtual ProGroup ProGroup { get; set; }
        public virtual ProType ProType { get; set; }
        public virtual ICollection<AccBasket> AccBasket { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetail { get; set; }
        public virtual ICollection<ProSpecification> ProSpecification { get; set; }
        public virtual ICollection<ProVariant> ProVariant { get; set; }
        public virtual ICollection<ProView> ProView { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }
    }
}
