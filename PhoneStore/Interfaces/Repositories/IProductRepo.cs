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
        ICollection<Product> GetAllProducts();
        ICollection<Product> GetProductsByGroup(int gid);
        ICollection<Product> GetProductsByType(int gid, int tid);
        ICollection<Product> GetProductsByBrand(int gid, int? tid, int bid);
        ProVariant GetVariant(int vid);

        ICollection<BrandGroup> GetBrands(int gid, int? tid);
        ICollection<BrandGroup> GetGroup(int gid);

        ICollection<VarImages> GetVariantImage(int id);
        

      
        ICollection<AddressCity> GetCities();
        ICollection<AddressDistrict> GetDistricts(int cid);
        ICollection<AddressWard> GetWards(int did);

        double GetProductPrice(int pid);

     
        ICollection<Product> GetRelatedProducts(Product product);
        void SaveChanges();
    }
}
