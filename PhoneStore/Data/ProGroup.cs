using System;
using System.Collections.Generic;

namespace PhoneStore.Data
{
    public partial class ProGroup
    {
        public ProGroup()
        {
            BrandGroup = new HashSet<BrandGroup>();
            ProType = new HashSet<ProType>();
            Product = new HashSet<Product>();
        }

        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public virtual ICollection<BrandGroup> BrandGroup { get; set; }
        public virtual ICollection<ProType> ProType { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
