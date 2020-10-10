using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhoneStore.Data;

namespace PhoneStore.Models.ViewModel
{
    public class IndexModel
    {
       public ICollection<Product> Products { get; set; }
       public ICollection<Invoice> Invoices { get; set; }
       
    }
}
