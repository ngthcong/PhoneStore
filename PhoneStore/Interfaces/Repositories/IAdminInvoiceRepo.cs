using PhoneStore.Data;
using PhoneStore.Models.ViewModel.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Interfaces.Repository
{
    public interface IAdminInvoiceRepo
    {
        ICollection<Invoice> GetAllInvoice();
        ICollection<Invoice> GetPendingInvoice();
        Invoice GetInvoice(int id);
        ICollection<Invoice> SearchInvoiceByCusPhone(string phone);
        ICollection<Invoice> SearchInvoiceByCusName(string name);

    }
}
