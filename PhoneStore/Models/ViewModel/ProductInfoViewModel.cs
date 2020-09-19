using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Models.ViewModel
{
    public class ProductInfoViewModel
    {
        public ProductViewModel pro { get; set; }
        public IEnumerable<SpecViewModel> spec { get; set; }
        public IEnumerable<VariantViewModel> variant { get; set; }
        public IEnumerable<ImageViewModel> imageList { get; set; }
    }
}
