using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.VisualBasic;
using PhoneStore.CustomHandler;
using PhoneStore.Data;
using PhoneStore.Interfaces;
using PhoneStore.Interfaces.Repositories;
using PhoneStore.Interfaces.Services;
using PhoneStore.Models;
using PhoneStore.Models.FormModel;
using PhoneStore.Models.Response;
using PhoneStore.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Threading.Tasks;

namespace PhoneStore.Services
{

    public class ProductService : IProductService
    {
        private readonly IProductRepo _repo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hosting;
        private readonly IRepository<ProVariant> _variantRepo;

        public ProductService(IProductRepo repo, IMapper mapper, IWebHostEnvironment hosting, IRepository<ProVariant> variantRepo )
        {
            _repo = repo;
            _mapper = mapper;
            _hosting = hosting;
            _variantRepo = variantRepo;
        }

        public void AddDescription(DescriptionModel des)
        {
            Product _product = _repo.GetProduct(des.proid);
            string[] _base64List = FileManager.ExtractBase64Image(des.description);
            string dir = "\\webimage\\productimage\\"
                + DateTime.Now.Year.ToString()
                + "\\" + DateTime.Now.Month.ToString()
                + "\\" + DateTime.Now.Day.ToString();


            for (int i = 0; i < _base64List.Length; i++)
            {
                if (FileManager.IsBase64Image(_base64List[i]))
                {
                    string _base64 = FileManager.ExtractBase64(_base64List[i]);
                    string name = FileManager.GetImageName(_base64List[i + 1]);
                    string imageName = UploadBase64Image(name, _base64);
                    string imageAttr = FileManager.GetImageAttr(_base64List[i + 1]);
                    des.description = FileManager.ReplaceImageSrc(des.description, _base64List[i], dir + "\\" + imageName);
                    des.description = FileManager.ReplaceImageSrc(des.description, imageAttr, ">");

                }

            }
            _product.ProDescription = des.description;
            _repo.SaveChanges();
        }

        public void AddVariant(VariantModel v)
        {


            string _iconImage = UploadImageAsync(v.proColorIcon);




            ProVariant proVariant = new ProVariant()
            {
                ProId = v.proId,
                VarColor = v.color,
                VarQty = v.proQty,
                VarColorIcon = _iconImage,
                VarStatus = v.proStatus,
                DateCreated = DateTime.Now
            };
            _repo.AddPhoneVariant(proVariant);
            _repo.SaveChanges();

            for (int i = 0; i < 4; i++)
            {
                VarImages varImages = new VarImages()
                {
                    ImgPath = UploadImageAsync(v.proColorImage[i]),
                    VarId = proVariant.VarId,
                    ImgIndex = i + 1,
                };
                _repo.AddVariantImages(varImages);
                _repo.SaveChanges();
            }
        }
        public void UpdateVariant(VariantModel v)
        {
            ProVariant variant = _variantRepo.GetByID(v.proId.Value);
            variant.VarColor = v.color;
            variant.VarQty = v.proQty;
            variant.VarStatus = v.proStatus;

            if (v.proColorIcon != null)
            {
                string _iconImage = UploadImageAsync(v.proColorIcon);
                variant.VarColorIcon = _iconImage;
            }
            
            _variantRepo.Update(variant);
            _variantRepo.SaveChanges();

            if (v.proColorImage != null)
            {
                for (int i = 0; i < 4; i++)
                {
                    VarImages varImages = new VarImages()
                    {
                        ImgPath = UploadImageAsync(v.proColorImage[i]),
                        VarId = variant.VarId,
                        ImgIndex = i + 1,
                    };
                    _repo.AddVariantImages(varImages);
                    _repo.SaveChanges();
                }
            }
            Product product = GetProduct(variant.ProId.Value);
            if(product.ProVariant.Where(x =>x.VarStatus.Value == true).Count() == 0)
            {
                product.ProStatus = false;
                _repo.SaveChanges();
            }

        }



        public Response<string> AddProductAsync<T>(ProductModel model, T t)
        {
            string imageName = UploadImageAsync(model.proImageStream);
            Product product = _mapper.Map<Product>(model);
            product.DateCreated = DateTime.Now;
            product.ProStatus = false;
            product.ProImage = imageName;
            int proId = _repo.AddProduct(product);

            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                string[] _specInfo = FileManager.StringSeparator(property.GetValue(t, null).ToString(), "//");
                ProSpecification spec = new ProSpecification()
                {
                    ProId = proId,
                    SpecId = Int16.Parse(_specInfo[0]),
                    SpecValue = _specInfo[1]
                };
                _repo.AddProductSpec(spec);
                _repo.SaveChanges();

            }
            Response<string> res = new Response<string>()
            {
                IsSuccess = true,
                Code = "200",
                Message = "Thêm sản phẩm thành công",
                Data = "/admin/addvariant?pid=" + proId
            };
            return res;

        }



        public ICollection<Product> GetAllProduct()
        {
            return _repo.GetAllProducts();
            
        }

        public HeaderViewModel GetMenu()
        {
            HeaderViewModel menu = new HeaderViewModel()
            {
                Phone = _repo.GetGroup(1),
                Accesscories = _repo.GetGroup(2),
                Laptops = _repo.GetGroup(3)

            };
            return menu;
        }

        public Product GetProduct(int gid)
        {
           return _repo.GetProduct(gid);
        }
        public ICollection<Product> GetAllProducts()
        {
            return _repo.GetAllProducts();
        }

        public ICollection<Product> GetProductsByType(int gid, int tid)
        {
           return _repo.GetProductsByType(gid, tid);
        }
        public ICollection<Product> GetProductsByGroup(int gid)
        {
           return _repo.GetProductsByGroup(gid);
        }
        public ICollection<Product> GetProductsByBrand(int gid,int? tid, int bid)
        {
           return _repo.GetProductsByBrand(gid, null, bid);
        }

        public ICollection<VarImages> GetProductImage(int vid)
        {
           return _repo.GetVariantImage(vid);
         
        }

        public ProductInfoViewModel GetProductInfo(int pid)
        {
            var product = _repo.GetProduct(pid);
            ProductInfoViewModel model = new ProductInfoViewModel()
            {

                Product = product,
                ImageList = _repo.GetVariantImage(product.ProVariant.First().VarId),
                Related = _repo.GetRelatedProducts(_repo.GetProduct(pid))
            };

            return model;

        }

        public ProtNameViewModel GetProName(int pid)
        {
            ProtNameViewModel viewModel = _mapper.Map<ProtNameViewModel>(_repo.GetProduct(pid));
            return viewModel;
        }

        public string UploadBase64Image(string name, string image)
        {
            var bytes = Convert.FromBase64String(image);// a.base64image 
            //or full path to file in temp location
            var filePath = Path.GetTempFileName();
            var uniqueFileName = FileManager.GetUniqueName("des_" + name);
            // full path to file in current project location
            string dir = "webimage\\productimage\\"
                + DateTime.Now.Year.ToString()
                + "\\" + DateTime.Now.Month.ToString()
                + "\\" + DateTime.Now.Day.ToString();
            string filedir = Path.Combine(_hosting.WebRootPath, dir);

            if (!Directory.Exists(filedir))
            { //check if the folder exists;
                Directory.CreateDirectory(filedir);
            }
            string file = Path.Combine(filedir, uniqueFileName);




            if (bytes.Length > 0)
            {
                using (var stream = new FileStream(file, FileMode.Create))
                {
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Flush();
                }
            }
            return uniqueFileName;
        }



        public string UploadImageAsync(IFormFile file)
        {

            var uniqueFileName = FileManager.GetUniqueName(file.FileName);
            string dir = "webimage\\productimage\\"
                + DateTime.Now.Year.ToString()
                + "\\" + DateTime.Now.Month.ToString()
                + "\\" + DateTime.Now.Day.ToString();
            var filedir = Path.Combine(_hosting.WebRootPath, dir);
            if (!Directory.Exists(filedir))
            { //check if the folder exists;
                Directory.CreateDirectory(filedir);
            }
            var filePath = Path.Combine(filedir, uniqueFileName);


            file.CopyTo(new FileStream(filePath, FileMode.Create));


            return Path.Combine(dir, uniqueFileName); ;
        }

        public ICollection<CityViewModel> GetCities()
        {
            ICollection<CityViewModel> citiesList = _mapper.Map<ICollection<CityViewModel>>(_repo.GetCities());
            return citiesList;
        }

        public Response<ICollection<DistrictViewModel>> GetDistricts(int cid)
        {
            ICollection<DistrictViewModel> districtList = _mapper.Map<ICollection<DistrictViewModel>>(_repo.GetDistricts(cid));
            Response<ICollection<DistrictViewModel>> res = new Response<ICollection<DistrictViewModel>>()
            {
                IsSuccess = true,
                Code = "200",
                Message = "",
                Data = districtList
            };
            return res;
        }

        public Response<ICollection<WardViewModel>> GetWards(int did)
        {
            ICollection<WardViewModel> wardList = _mapper.Map<ICollection<WardViewModel>>(_repo.GetWards(did));
            Response<ICollection<WardViewModel>> res = new Response<ICollection<WardViewModel>>()
            {
                IsSuccess = true,
                Code = "200",
                Message = "",
                Data = wardList
            };
            return res;
        }

        public Product Update(Product product)
        {
          Product oldProduct =   _repo.GetProduct(product.ProId);
            if (oldProduct == null)
                return oldProduct;
            oldProduct.ProName = product.ProName;
            oldProduct.ProSalePrice = product.ProSalePrice;
            oldProduct.ProStatus = product.ProStatus;
            oldProduct.ProRetailPrice = product.ProRetailPrice;

            _repo.Update(oldProduct);
            _repo.SaveChanges();
            return oldProduct;
        }
    }
}
