using PhoneStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Models.ViewModel
{
    public class ProductInfoViewModel
    {
        public Product Product { get; set; }
        public ICollection<VarImages> ImageList { get; set; }
        public ICollection<Product> Related { get; set; }
    }
}
