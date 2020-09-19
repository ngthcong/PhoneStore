using PhoneStore.Data;
using PhoneStore.Models;
using PhoneStore.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Interfaces
{
    public interface IProductRepo
    {
        int AddProduct(Product p);
        void AddProductSpec(ProSpecification p);
        void AddPhoneVariant(ProVariant v);
        void AddVariantImages(VarImages vim);
        Product GetProduct(int pid);
        IEnumerable<Product> GetProducts(int gid, bool v);
        IEnumerable<Product> GetProducts(int gid, int tid, bool v);
        IEnumerable<Product> GetProductsByBrand(int gid, int bid, bool s);
        IEnumerable<Product> GetPhoneByBrand(int bid, bool s);
        Product GetProductById(int pid, bool s);
        IEnumerable<SpecViewModel> GetProductSpec(int pid);
        IEnumerable<ProVariant> GetProVariant(int pid, bool v);
        IEnumerable<VarImages> GetVariantImage(int id, bool s);
        IEnumerable<Product> GetAllProduct();
        IEnumerable<ProBrand> GetBrand(int gid);
        IEnumerable<ProBrand> GetBrand(int gid, int tid);
        IEnumerable<ProType> GetType(int gid); 
        IEnumerable<AddressCity> GetCities(); 
        IEnumerable<AddressDistrict> GetDistricts(int cid); 
        IEnumerable<AddressWard> GetWards(int did); 

        void SaveChanges();
    }
}
