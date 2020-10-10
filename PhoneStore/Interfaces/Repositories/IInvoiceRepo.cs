using PhoneStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Interfaces.Repository
{
    public interface IInvoiceRepo
    {
        void AddInvoice(Invoice model);

        void AddInvoiceDetail(InvoiceDetail invoiceDetails);

        void SaveChanges();

    }
}
