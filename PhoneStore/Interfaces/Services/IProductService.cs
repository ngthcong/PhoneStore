using Microsoft.AspNetCore.Http;
using PhoneStore.Data;
using PhoneStore.Models;
using PhoneStore.Models.FormModel;
using PhoneStore.Models.Response;
using PhoneStore.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Interfaces.Services
{
    public interface IProductService
    {
        Response<string> AddProductAsync<T>(ProductModel model, T t);

        void AddVariant(VariantModel v);
        void AddDescription(DescriptionModel des);
        ProtNameViewModel GetProName(int pid);
        ICollection<Product> GetAllProduct();
        Product GetProduct(int gid);
        ICollection<Product> GetProductsByType(int gid, int tid);
        ICollection<Product> GetProductsByBrand(int gid, int? tid, int bid);
        ICollection<Product> GetProductsByGroup(int gid);
        ProductInfoViewModel GetProductInfo(int pid);
        ICollection<VarImages> GetProductImage(int vid);
        ICollection<CityViewModel> GetCities();
        Response<ICollection<DistrictViewModel>> GetDistricts(int cid);
        Response<ICollection<WardViewModel>> GetWards(int did);

        HeaderViewModel GetMenu();

        string UploadImageAsync(IFormFile file);
        string UploadBase64Image(string name, string image);

    }
}
