using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PhoneStore.Data;
using PhoneStore.Interfaces;
using PhoneStore.Models;
using PhoneStore.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PhoneStore.Repository
{
    public class ProductRepo : IProductRepo
    {
        private readonly PhoneStoreDBContext _context;

        public ProductRepo(PhoneStoreDBContext context)
        {
            _context = context;
        }

        public void AddPhoneVariant(ProVariant v)
        {
            _context.ProVariant.Add(v);
        }

        public int AddProduct(Product p)
        {
            _context.Product.Add(p);
            _context.SaveChanges();
            return p.ProId;
        }

        public void AddProductSpec(ProSpecification p)
        {
            _context.ProSpecification.Add(p);
        }

        public Product GetProduct(int pid)
        {
            return _context.Product.Where(i => i.ProId == pid).SingleOrDefault();
        }

        IEnumerable<Product> IProductRepo.GetPhoneByBrand(int bid, bool s)
        {
            return _context.Product.Where(i => i.ProBrandId == bid && i.ProStatus == s).ToList();
        }

        IEnumerable<Product> IProductRepo.GetProducts(int gid, bool v)
        {
            return _context.Product.Where(i => i.ProGroupId == gid && i.ProStatus == v).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return _context.Product.OrderByDescending(i => i.ProId).ToList();
        }

        public Product GetProductById(int pid, bool s)
        {
            return _context.Product.Where(i => i.ProId == pid).SingleOrDefault();
        }

        public IEnumerable<SpecViewModel> GetProductSpec(int pid)
        {
            IEnumerable<SpecViewModel> spec = from i in _context.Specification
                                              join c in _context.ProSpecification on i.SpecId equals c.SpecId
                                              where c.ProId == pid
                                              orderby c.Id
                                              select new SpecViewModel()
                                              {
                                                  specName = i.SpecName,
                                                  SpecValue = c.SpecValue
                                              };


            return spec;
        }

        public IEnumerable<ProVariant> GetProVariant(int pid, bool v)
        {
            return _context.ProVariant.Where(i => i.ProId == pid && i.VarStatus == v).OrderBy(i => i.ProId);
        }

        public IEnumerable<VarImages> GetVariantImage(int id, bool v)
        {
            return _context.VarImages.Where(i => i.VarId == id).ToList();
        }

        public IEnumerable<ProBrand> GetBrand(int gid)
        {

            var brands = from i in _context.ProBrand
                         join x in _context.BrandGroup on i.BrandId equals x.BrandId
                         where i.BrandId == x.BrandId
                         where x.GroupId == gid
                         select i;
            return brands;
        }

        public IEnumerable<ProBrand> GetBrand(int gid, int tid)
        {
            var brands = from i in _context.ProBrand
                         join x in _context.BrandGroup on i.BrandId equals x.BrandId
                         where i.BrandId == x.BrandId
                         where x.GroupId == gid
                         where x.TypeId == tid
                         select i;
            return brands;
        }

        public IEnumerable<ProType> GetType(int gid)
        {
            return _context.ProType.Where(i => i.GroupId == gid).ToList();
        }

        public IEnumerable<Product> GetProducts(int gid, int tid, bool v)
        {
            return _context.Product.Where(i => i.ProGroupId == gid && i.ProTypeId == tid && i.ProStatus == v).ToList();
        }

        public IEnumerable<Product> GetProductsByBrand(int gid, int bid, bool s)
        {
            return _context.Product.Where(i => i.ProGroupId == gid && i.ProBrandId == bid && i.ProStatus == s).ToList();
        }

        public void AddVariantImages(VarImages vim)
        {
            _context.Add(vim);
        }

        public IEnumerable<AddressCity> GetCities()
        {
            return _context.AddressCity.ToList();
        }

        public IEnumerable<AddressDistrict> GetDistricts(int cid)
        {
            return _context.AddressDistrict.Where(i => i.CityId == cid).ToList();        
        }

        public IEnumerable<AddressWard> GetWards(int did)
        {
            return _context.AddressWard.Where(i => i.DistrictId == did).ToList();
        }
    }
}
