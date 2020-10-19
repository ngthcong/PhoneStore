using PhoneStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Models.ViewModel.InvoiceModel
{
    public class InvoiceDetailViewModel
    {
        public Invoice Invoice { get; set; }
        public ICollection<AddressCity> Cities { get; set; }
        public ICollection<AddressDistrict> AddressDistricts { get; set; }
        public ICollection<AddressWard> AddressWards { get; set; }
    }
}
