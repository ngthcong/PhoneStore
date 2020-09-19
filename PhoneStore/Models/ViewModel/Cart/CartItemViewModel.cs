using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Models.ViewModel
{
    public class CartItemViewModel
    {
        public int ProId { get; set; }
        public string ProName { get; set; }
        public string ProImage { get; set; }
        public string varImage { get; set; }
        public int qty { get; set; }
        public double? ProRetailPrice { get; set; }
        public double? ProSalePrice { get; set; }
        public string ProDescription { get; set; }
        public IEnumerable<VariantViewModel> VariantList { get; set; } 
    }
}
