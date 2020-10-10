using Microsoft.EntityFrameworkCore;
using PhoneStore.Data;
using PhoneStore.Interfaces.Repository;
using PhoneStore.Models.ViewModel.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Repository
{
    public class AdminProductRepo : IAdminProductRepo
    {
        private readonly PhoneStoreDBContext _context;

        public AdminProductRepo(PhoneStoreDBContext context)
        {
            _context = context;
        }

        public ICollection<Product> GetAllProduct()
        {
            return _context.Product.Include(i => i.ProGroup).Include(i => i.ProVariant).Include(i =>i.ProType).ToList(); 
        }

        public ICollection<Product> GetProductByName(string pname)
        {
            return _context.Product.Where(i => EF.Functions.Like(i.ProName, pname)).ToList();
        }

        public Product GetProduct(int pid)
        {
            return _context.Product
                .Include(i => i.ProGroup)
                .Include(i => i.ProVariant)
                .Include(i => i.ProType)
                .Include(i => i.ProSpecification).ThenInclude(i =>i.Spec)
                .Where(i => i.ProId == pid)
                .FirstOrDefault();
        }

        public ProVariant GetVariant(int vid)
        {
            return _context.ProVariant.Include(i => i.Pro).Where(i => i.VarId == vid).FirstOrDefault();
        }


    }
}
