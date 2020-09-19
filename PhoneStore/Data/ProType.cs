using System;
using System.Collections.Generic;

namespace PhoneStore.Data
{
    public partial class ProType
    {
        public ProType()
        {
            BrandGroup = new HashSet<BrandGroup>();
            Product = new HashSet<Product>();
        }

        public int TypeId { get; set; }
        public int? GroupId { get; set; }
        public string TypeName { get; set; }

        public virtual ProGroup Group { get; set; }
        public virtual ICollection<BrandGroup> BrandGroup { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
