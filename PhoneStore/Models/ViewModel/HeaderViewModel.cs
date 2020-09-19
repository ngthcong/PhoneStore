using PhoneStore.Models.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Models.ViewModel
{
    public class HeaderViewModel
    {
        public IEnumerable<BrandViewModel> brands { get; set; }
        public IEnumerable<TypeViewModel> types { get; set; }
        public UserViewModel user { get; set; }
        public int cartCount { get; set;}
    }


}
