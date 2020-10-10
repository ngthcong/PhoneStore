using PhoneStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Models.ViewModel
{
    public class IndexViewModel
    {
        public IEnumerable<Product> accessories { get; set; }
        public IEnumerable<Product> phones { get; set; }
        public IEnumerable<Product> laptops { get; set; }
        public IEnumerable<Product> hots { get; set; }
    }
}
