using System;
using System.Collections.Generic;

namespace PhoneStore.Data
{
    public partial class AddressDistrict
    {
        public AddressDistrict()
        {
            AddressWard = new HashSet<AddressWard>();
        }

        public int DistrictId { get; set; }
        public int? CityId { get; set; }
        public string DistrictName { get; set; }

        public virtual AddressCity City { get; set; }
        public virtual ICollection<AddressWard> AddressWard { get; set; }
    }
}
