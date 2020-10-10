using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhoneStore.Data;

namespace PhoneStore.Models.ViewModel.ProductModel
{
    public class AdminProductInfo
    {
        public PhoneStore.Data.Product product { get; set; }
        public ProVariant proVariant { get; set; }

        public IEnumerable<ProVariant> proVariants { get; set; }
        public ICollection<ProSpecification> proSpecifications { get; set; }
    }
}
