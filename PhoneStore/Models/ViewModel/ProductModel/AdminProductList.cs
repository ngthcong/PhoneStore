using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Models.ViewModel.ProductModel
{
    public class AdminProductList
    {
        public int ProId { get; set; }
        public string ProName { get; set; }
        public string ProImage { get; set; }
        public string ProGroup { get; set; }
        public double? ProRetailPrice { get; set; }
        public double? ProSalePrice { get; set; }
        public bool? ProStatus { get; set; }
        public double? VarQty { get; set; }
        
    }
}
