using System;
using System.Collections.Generic;

namespace PhoneStore.Data
{
    public partial class AddressCity
    {
        public AddressCity()
        {
            AddressDistrict = new HashSet<AddressDistrict>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<AddressDistrict> AddressDistrict { get; set; }
    }
}
