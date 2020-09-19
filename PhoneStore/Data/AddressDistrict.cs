using System;
using System.Collections.Generic;

namespace PhoneStore.Data
{
    public partial class AddressDistrict
    {
        public AddressDistrict()
        {
            Account = new HashSet<Account>();
            AddressWard = new HashSet<AddressWard>();
            Invoice = new HashSet<Invoice>();
        }

        public int DistrictId { get; set; }
        public int? CityId { get; set; }
        public string DistrictName { get; set; }

        public virtual AddressCity City { get; set; }
        public virtual ICollection<Account> Account { get; set; }
        public virtual ICollection<AddressWard> AddressWard { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
