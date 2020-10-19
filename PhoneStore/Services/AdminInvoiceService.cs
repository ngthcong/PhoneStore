﻿using Microsoft.EntityFrameworkCore;
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
        private readonly IRepository<ProVariant> _variantRepo;

        public AdminInvoiceService(IRepository<Invoice> invoiceRepo, IRepository<ProVariant> variantRepo)
        {
            _invoiceRepo = invoiceRepo;
            _variantRepo = variantRepo;
        }

        public ICollection<Invoice> GetAllInvoice()
        {
            return _invoiceRepo.Get(includeProperties: x => x.Include(x => x.InvoiceDetail));
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
          return  _invoiceRepo.Get(filter: x=>x.InvStatus == null,includeProperties: x =>x.Include(x =>x.InvoiceDetail));
        }

        public ICollection<Invoice> SearchInvoiceByCusName(string name)
        {
            throw new NotImplementedException();
        }

        public ICollection<Invoice> SearchInvoiceByCusPhone(string phone)
        {
            throw new NotImplementedException();
        }
        public Invoice ConfirmOrder(Invoice newInvoice)
        {
           Invoice oldInvoice =  _invoiceRepo.Get(filter: x =>x.InvId == newInvoice.InvId,includeProperties: x =>x.Include(x =>x.InvoiceDetail)).FirstOrDefault();
            if (oldInvoice == null)
                return oldInvoice;
            else
            {
                oldInvoice.InvCusName = newInvoice.InvCusName;
                oldInvoice.InvAddress = newInvoice.InvAddress;
                oldInvoice.InvCusEmail = newInvoice.InvCusEmail;
                oldInvoice.InvCusPhone = newInvoice.InvCusPhone;
                oldInvoice.InvDate = DateTime.Now;
                oldInvoice.InvWardId = newInvoice.InvWardId;
                oldInvoice.EmId = newInvoice.EmId;
                oldInvoice.InvStatus = newInvoice.InvStatus;
                _invoiceRepo.Update(oldInvoice);
                _invoiceRepo.SaveChanges();

                foreach(InvoiceDetail item in oldInvoice.InvoiceDetail)
                {
                    UpdateQuantity(item);
                }
                return oldInvoice;
            }
        }
        public void UpdateQuantity(InvoiceDetail invoiceDetail)
        {
         ProVariant variant =    _variantRepo.GetByID(invoiceDetail.VarId);
            variant.VarQty -= invoiceDetail.ProQty;
            _variantRepo.Update(variant);
            _variantRepo.SaveChanges();
        }
       
    }
}
