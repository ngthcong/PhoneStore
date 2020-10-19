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
            return _context.Product
                .Include(i => i.ProGroup)
                .Include(i => i.ProVariant)
                .Include(i => i.ProType)
                .Include(i => i.ProSpecification).ThenInclude(i => i.Spec)
                .Where(i => i.ProId == pid)
                .FirstOrDefault();
        }
        public ICollection<Product> GetAllProducts()
        {
            return _context.Product
                .Include(i => i.ProGroup)
                .Include(i => i.ProVariant)
                .Include(i => i.ProType)
                .Include(i => i.ProSpecification).ThenInclude(i => i.Spec)
                .Where(i => i.ProStatus == true).ToList();
        }
        public ICollection<Product> GetProductsByGroup(int gid)
        {
            return _context.Product
                .Include(i => i.ProGroup)
                .Include(i => i.ProVariant)
                .Include(i => i.ProType)
                .Include(i => i.ProSpecification).ThenInclude(i => i.Spec)
                .Where(i=>  i.ProStatus == true && i.ProGroupId == gid).ToList();
        }
        public ICollection<Product> GetProductsByType(int gid, int tid)
        {
            return _context.Product
                .Include(i => i.ProGroup)
                .Include(i => i.ProVariant)
                .Include(i => i.ProType)
                .Include(i => i.ProSpecification).ThenInclude(i => i.Spec)
                .Where(i => i.ProStatus == true && i.ProTypeId == tid && i.ProGroupId == gid).ToList();
        }
        public ICollection<Product> GetProductsByBrand(int gid, int? tid, int bid)
        {
            return _context.Product
                .Include(i => i.ProGroup)
                .Include(i => i.ProVariant)
                .Include(i => i.ProType)
                .Include(i => i.ProSpecification).ThenInclude(i => i.Spec)
                .Where(i => i.ProStatus == true && i.ProTypeId == tid && i.ProGroupId == gid && i.ProBrandId == bid).ToList();
        }
        public ProVariant GetVariant(int vid)
        {
            return _context.ProVariant.Include(i => i.Pro).Where(i => i.VarId == vid && i.VarStatus == true).FirstOrDefault();
        }

        public ICollection<VarImages> GetVariantImage(int id)
        {
            return _context.VarImages.Where(i => i.VarId == id).ToList();
        }
        public ICollection<BrandGroup> GetGroup(int gid)
        {
            return _context.BrandGroup.Include(i => i.Group).Include(i => i.Type).Include(i => i.Brand).Where(i => i.GroupId == gid).Distinct().ToList();
        }
        public ICollection<BrandGroup> GetBrands(int gid, int? tid)
        {
            return _context.BrandGroup.Include(i => i.Group).Include(i => i.Type).Where(i => i.GroupId == gid && i.TypeId == tid).ToList();
        }



        public void AddVariantImages(VarImages vim)
        {
            _context.Add(vim);
        }

        

        

        public double GetProductPrice(int pid)
        {
            return _context.Product.Where(i => i.ProId == pid).Select(i => i.ProSalePrice == null ? i.ProRetailPrice.Value : i.ProSalePrice.Value).SingleOrDefault();
        }


        

        public ICollection<Product> GetRelatedProducts(Product product)
        {
            double up = product.ProRetailPrice.Value + 2000000;
            double down = product.ProRetailPrice.Value - 2000000;
            return _context.Product.Where(i => i.ProRetailPrice > down).Where(i => i.ProRetailPrice < up).OrderBy(r => Guid.NewGuid()).Take(4).ToList();
        }



        public void Update (Product product )
        {
            _context.Update(product);
        }


        #region Address
        public ICollection<AddressCity> GetCities()
        {
            return _context.AddressCity.ToList();
        }

        public ICollection<AddressDistrict> GetDistricts(int cid)
        {
            return _context.AddressDistrict.Where(i => i.CityId == cid).ToList();
        }

        public ICollection<AddressWard> GetWards(int did)
        {
            return _context.AddressWard.Where(i => i.DistrictId == did).ToList();
        }
        #endregion


        public void SaveChanges()
        {
            _context.SaveChanges();
        }



    }
}
