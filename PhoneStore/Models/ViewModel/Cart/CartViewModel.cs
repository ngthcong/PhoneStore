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
        public IEnumerable<CityViewModel> cities { get; set; }
    }
}
