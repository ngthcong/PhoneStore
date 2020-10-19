using PhoneStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Models.ViewModel
{
    public class CartViewModel
    {
        public IEnumerable<CartItemViewModel> cartItem { get; set; }
        public CartPriceViewModel cartPrice { get; set; }
        public IEnumerable<AddressCity> cities { get; set; }
        public IEnumerable<AddressDistrict> district { get; set; }
        public IEnumerable<AddressWard> ward { get; set; }
        public Account Account { get; set; }
    }
}
