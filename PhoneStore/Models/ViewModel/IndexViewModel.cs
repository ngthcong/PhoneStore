using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Models.ViewModel
{
    public class IndexViewModel
    {
        public IEnumerable<ProductViewModel> accessories { get; set; }
        public IEnumerable<ProductViewModel> phones { get; set; }
        public IEnumerable<ProductViewModel> laptops { get; set; }
        public IEnumerable<ProductViewModel> hots { get; set; }
    }
}
