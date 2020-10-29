using PhoneStore.Data;
using PhoneStore.Interfaces;
using PhoneStore.Interfaces.Repositories;
using PhoneStore.Interfaces.Repository;
using PhoneStore.Interfaces.Services;
using PhoneStore.Models;
using PhoneStore.Models.ViewModel;

using PhoneStore.Models.ViewModel.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Services
{
    public class AdminProductService : IAdminProductService
    {
        private readonly IAdminProductRepo _adminProductRepo;
        private readonly IAdminInvoiceRepo _adminInvoiceRepo;
        private readonly IProductService _productService;
        private readonly IRepository<ProVariant> _variantRepo;
        private readonly IProductRepo _productRepo;

        public AdminProductService(IRepository<ProVariant> variantRepo,IAdminProductRepo adminProductRepo, IAdminInvoiceRepo adminInvoiceRepo, IProductService productService)
        {
            _adminProductRepo = adminProductRepo;
            _adminInvoiceRepo = adminInvoiceRepo;
            _productService = productService;
            _variantRepo = variantRepo;
        }

        public ICollection<Product> GetAllProduct()
        {
            return _adminProductRepo.GetAllProduct();
        }

        public Product GetProduct(int pid)
        {
            return _adminProductRepo.GetProduct(pid);
        }

        public ProVariant GetVariant(int vid)
        {
            return _adminProductRepo.GetVariant(vid);
        }

        public ICollection<ProVariant> GetProVariants(int pid)
        {
            throw new NotImplementedException();
        }
       
    }
}
