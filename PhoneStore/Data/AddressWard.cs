using System;
using System.Collections.Generic;

namespace PhoneStore.Data
{
    public partial class AddressWard
    {
        public AddressWard()
        {
            Account = new HashSet<Account>();
            Invoice = new HashSet<Invoice>();
        }

        public int WardId { get; set; }
        public int? DistrictId { get; set; }
        public string WardName { get; set; }

        public virtual AddressDistrict District { get; set; }
        public virtual ICollection<Account> Account { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
