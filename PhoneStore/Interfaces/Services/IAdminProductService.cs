using PhoneStore.Data;
using PhoneStore.Models.ViewModel;
using PhoneStore.Models.ViewModel.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Interfaces.Services
{
    public interface IAdminProductService
    {
        ICollection<Product> GetAllProduct();
        public Product GetProduct(int pid);

        public ICollection<ProVariant> GetProVariants(int pid);
        public ProVariant GetVariant(int vid);


    }
}