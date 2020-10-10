using Microsoft.EntityFrameworkCore;
using PhoneStore.Data;
using PhoneStore.Interfaces.Repository;
using PhoneStore.Models.ViewModel.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Repository
{
    public class AdminInvoiceRepo : IAdminInvoiceRepo
    {
        private readonly PhoneStoreDBContext _context;

        public AdminInvoiceRepo(PhoneStoreDBContext context)
        {
            _context = context;
        }

        public ICollection<Invoice> GetAllInvoice()
        {
            return _context.Invoice.Include(i => i.Cus).Include(i => i.InvoiceDetail).ToList();
        }

        public Invoice GetInvoice(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Invoice> GetPendingInvoice()
        {
            return _context.Invoice.Include(i => i.Cus).Include(i=>i.InvoiceDetail).Where(i => i.InvStatus == null).ToList();
        }

        public ICollection<Invoice> SearchInvoiceByCusName(string name)
        {
            throw new NotImplementedException();
        }

        public ICollection<Invoice> SearchInvoiceByCusPhone(string phone)
        {
            throw new NotImplementedException();
        }

  
    }
}
