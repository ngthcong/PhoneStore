using Microsoft.EntityFrameworkCore;
using PhoneStore.Data;
using PhoneStore.Interfaces.Repositories;
using PhoneStore.Interfaces.Repository;
using PhoneStore.Interfaces.Services;
using PhoneStore.Models.ViewModel.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Services
{
    public class AdminInvoiceService : IAdminInvoiceService
    {
        private readonly IRepository<Invoice> _invoiceRepo;

        public AdminInvoiceService(IRepository<Invoice> invoiceRepo)
        {
            _invoiceRepo = invoiceRepo;
        }

        public ICollection<Invoice> GetAllInvoice()
        {
            return _invoiceRepo.Get();
        }
        public Invoice GetInvoice(int id)
        {
            return _invoiceRepo.Get(filter: x=>x.InvId == id, includeProperties: i => i.Include(a =>a.Cus)
                                                                                        .Include(a =>a.Em)
                                                                                        .Include(a =>a.InvoiceDetail).ThenInclude(a =>a.Pro).ThenInclude(a =>a.ProVariant)
                                                                                        ).FirstOrDefault();
        }

        public ICollection<Invoice> GetPendingInvoice()
        {
          return  _invoiceRepo.Get(filter: x=>x.InvStatus == null);
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
