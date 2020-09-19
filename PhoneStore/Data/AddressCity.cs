using System;
using System.Collections.Generic;

namespace PhoneStore.Data
{
    public partial class AddressCity
    {
        public AddressCity()
        {
            Account = new HashSet<Account>();
            AddressDistrict = new HashSet<AddressDistrict>();
            Invoice = new HashSet<Invoice>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<Account> Account { get; set; }
        public virtual ICollection<AddressDistrict> AddressDistrict { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
