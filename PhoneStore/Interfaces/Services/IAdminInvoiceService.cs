using PhoneStore.Data;
using PhoneStore.Models.ViewModel.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Interfaces.Services
{
    public interface IAdminInvoiceService
    {
        ICollection<Invoice> GetPendingInvoice();
        ICollection<Invoice> GetAllInvoice();
        Invoice GetInvoice(int id);
        ICollection<Invoice> SearchInvoiceByCusPhone(string phone);
        ICollection<Invoice> SearchInvoiceByCusName(string name);
    } 
}
