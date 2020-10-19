using System;
using System.Collections.Generic;

namespace PhoneStore.Data
{
    public partial class Product
    {
        public Product()
        {
            InvoiceDetail = new HashSet<InvoiceDetail>();
            ProSpecification = new HashSet<ProSpecification>();
            ProVariant = new HashSet<ProVariant>();
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
        public virtual ICollection<InvoiceDetail> InvoiceDetail { get; set; }
        public virtual ICollection<ProSpecification> ProSpecification { get; set; }
        public virtual ICollection<ProVariant> ProVariant { get; set; }
    }
}
