using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Models
{
    public class ProductViewModel
    {
        public int ProId { get; set; }
        public string ProName { get; set; }
        public string ProImage { get; set; }

        public double? ProRetailPrice { get; set; }
        public double? ProSalePrice { get; set; }
        public string ProDescription { get; set; }

    }
}
