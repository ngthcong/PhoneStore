using PhoneStore.Data;
using PhoneStore.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Repository
{
    public class InvoiceRepo : IInvoiceRepo
    {
        private readonly PhoneStoreDBContext _context;

        public InvoiceRepo(PhoneStoreDBContext context)
        {
            _context = context;
        }
        public void AddInvoice(Invoice model)
        {
            _context.Invoice.Add(model);
        }
        public void AddInvoiceDetail(InvoiceDetail invoiceDetails)
        {
            _context.InvoiceDetail.Add(invoiceDetails);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
