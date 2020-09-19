using Microsoft.AspNetCore.Http;
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
        IEnumerable<ProductViewModel> GetAllProduct();
        IEnumerable<ProductViewModel> GetProducts(int gid);
        IEnumerable<ProductViewModel> GetProductsByType(int gid, int tid);
        IEnumerable<ProductViewModel> GetProductsByBrand(int gid, int bid);
        ProductInfoViewModel GetProductInfo(int pid);
        IEnumerable<ImageViewModel> GetProductImage(int vid);
        IEnumerable<CityViewModel> GetCities();
        Response<IEnumerable<DistrictViewModel>>  GetDistricts(int cid);
        Response<IEnumerable<WardViewModel>> GetWards(int did);

        HeaderViewModel GetMenu();

        string UploadImageAsync(IFormFile file);
        string UploadBase64Image(string name, string image);

    }
}
