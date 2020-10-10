using PhoneStore.Data;

using PhoneStore.Models.ViewModel.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Interfaces.Repository
{
    public interface IAdminProductRepo
    {
        ICollection<Product> GetAllProduct();

        ICollection<Product> GetProductByName(string pname);

        Product GetProduct(int pid);

        ProVariant GetVariant(int vid);
    }
}
