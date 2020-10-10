using System;
using System.Collections.Generic;

namespace PhoneStore.Data
{
    public partial class ProBrand
    {
        public ProBrand()
        {
            BrandGroup = new HashSet<BrandGroup>();
            Product = new HashSet<Product>();
        }

        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string BrandLogo { get; set; }

        public virtual ICollection<BrandGroup> BrandGroup { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
