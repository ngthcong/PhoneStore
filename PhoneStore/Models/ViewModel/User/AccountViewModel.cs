using PhoneStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Models.ViewModel.User
{
    public class AccountViewModel
    {
        public Account Account { get; set; }
        public ICollection<AddressCity> AddressCity { get; set; }
        public ICollection<AddressDistrict> AddressDistrict { get; set; }
        public ICollection<AddressWard> AddressWard { get; set; }
    }
}
