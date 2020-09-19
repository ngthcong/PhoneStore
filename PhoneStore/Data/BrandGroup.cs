using System;
using System.Collections.Generic;

namespace PhoneStore.Data
{
    public partial class BrandGroup
    {
        public int Id { get; set; }
        public int? GroupId { get; set; }
        public int? TypeId { get; set; }
        public int? BrandId { get; set; }

        public virtual ProGroup Group { get; set; }
        public virtual ProType Type { get; set; }
    }
}
