using PhoneStore.Data;
using PhoneStore.Models.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Models.ViewModel
{
    public class HeaderViewModel
    {
        public ICollection<BrandGroup> Phone { get; set; }
        public ICollection<BrandGroup> Accesscories { get; set; }
        public ICollection<BrandGroup> Laptops { get; set; }
        public Account user { get; set; }
        public int cartCount { get; set;}
    }


}
