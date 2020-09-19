using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.VisualBasic;
using PhoneStore.CustomHandler;
using PhoneStore.Data;
using PhoneStore.Interfaces;
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

        public ProductService(IProductRepo repo, IMapper mapper, IWebHostEnvironment hosting)
        {
            _repo = repo;
            _mapper = mapper;
            _hosting = hosting;
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


        //public void AddPhone(ProductModel model, PhoneModel p)
        //{
        //    string imageName = UploadImage(model.proName, "chung", model.proImageStream);
        //    Product product = _mapper.Map<Product>(model);
        //    product.ProVisible = false;
        //    product.ProTypeId = null;
        //    product.ProImage = imageName;
        //    int proId = _repo.AddProduct(product);


        //    int index = 1;
        //    Type type = typeof(PhoneModel);
        //    PropertyInfo[] properties = type.GetProperties();
        //    foreach (PropertyInfo property in properties)
        //    {
        //        ProSpecification spec = new ProSpecification()
        //        {
        //            ProId = proId,
        //            SpecIndex = index,
        //            SpecValue = property.GetValue(p, null).ToString()
        //        };

        //        _repo.AddProductSpec(spec);
        //        _repo.SaveChanges();
        //        index++;
        //    }

        //}



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

            for (int i = 0; i < v.proColorImage.Length; i++)
            {
                VarImages varImages = new VarImages()
                {
                    ImgPath = UploadImageAsync(v.proColorImage[i]),
                    VarId = proVariant.VarId,
                    Index = i + 1,
                };
                _repo.AddVariantImages(varImages);
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



        public IEnumerable<ProductViewModel> GetAllProduct()
        {
            IEnumerable<ProductViewModel> productList = _mapper.Map<IEnumerable<ProductViewModel>>(_repo.GetAllProduct());
            return productList;
        }

        public HeaderViewModel GetMenu()
        {
            HeaderViewModel menu = new HeaderViewModel()
            {
                brands = _mapper.Map<IEnumerable<BrandViewModel>>(_repo.GetBrand(1)),
                types = _mapper.Map<IEnumerable<TypeViewModel>>(_repo.GetType(2))
            };
            return menu;
        }

        public IEnumerable<ProductViewModel> GetProducts(int gid)
        {
            IEnumerable<ProductViewModel> productList = _mapper.Map<IEnumerable<ProductViewModel>>(_repo.GetProducts(gid, true));
            return productList;
        }

        public IEnumerable<ProductViewModel> GetProductsByType(int gid, int tid)
        {
            IEnumerable<ProductViewModel> productList = _mapper.Map<IEnumerable<ProductViewModel>>(_repo.GetProducts(gid, tid, true));
            return productList;
        }

        public IEnumerable<ImageViewModel> GetProductImage(int vid)
        {
            IEnumerable<ImageViewModel> imageList = _mapper.Map<IEnumerable<ImageViewModel>>(_repo.GetVariantImage(vid, true));





            return imageList;
        }

        public ProductInfoViewModel GetProductInfo(int pid)
        {
            IEnumerable<VariantViewModel> _variant = _mapper.Map<IEnumerable<VariantViewModel>>(_repo.GetProVariant(pid, true));


            int _varid = _variant.OrderBy(i => i.VarId).Select(i => i.VarId).FirstOrDefault();
            ProductInfoViewModel model = new ProductInfoViewModel()
            {

                pro = _mapper.Map<ProductViewModel>(_repo.GetProductById(pid, true)),
                spec = _mapper.Map<IEnumerable<SpecViewModel>>(_repo.GetProductSpec(pid)),
                variant = _variant,
                imageList = _mapper.Map<IEnumerable<ImageViewModel>>(_repo.GetVariantImage(_varid, true))
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

        public IEnumerable<ProductViewModel> GetPhoneByBrand(int bid, bool s)
        {
            IEnumerable<ProductViewModel> productList = _mapper.Map<IEnumerable<ProductViewModel>>(_repo.GetPhoneByBrand(bid, s));
            return productList;
        }

        public IEnumerable<ProductViewModel> GetProductsByBrand(int gid, int bid)
        {
            IEnumerable<ProductViewModel> productList = _mapper.Map<IEnumerable<ProductViewModel>>(_repo.GetProductsByBrand(gid, bid, true));
            return productList;
        }

        public IEnumerable<CityViewModel> GetCities()
        {
            IEnumerable<CityViewModel> citiesList = _mapper.Map<IEnumerable<CityViewModel>>(_repo.GetCities());
            return citiesList;
        }

        public Response<IEnumerable<DistrictViewModel>> GetDistricts(int cid)
        {
            IEnumerable<DistrictViewModel> districtList = _mapper.Map<IEnumerable<DistrictViewModel>>(_repo.GetDistricts(cid));
            Response<IEnumerable<DistrictViewModel>> res = new Response<IEnumerable<DistrictViewModel>>()
            {
                IsSuccess = true,
                Code = "200",
                Message = "",
                Data = districtList
            };
            return res;
        }

        public Response<IEnumerable<WardViewModel>> GetWards(int did)
        {
            IEnumerable<WardViewModel> wardList = _mapper.Map<IEnumerable<WardViewModel>>(_repo.GetWards(did));
            Response<IEnumerable<WardViewModel>> res = new Response<IEnumerable<WardViewModel>>()
            {
                IsSuccess = true,
                Code = "200",
                Message = "",
                Data = wardList
            };
            return res;
        }
    }
}
