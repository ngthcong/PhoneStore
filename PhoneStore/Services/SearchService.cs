using PhoneStore.Data;
using PhoneStore.Interfaces.Repositories;
using PhoneStore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Services
{
    public class SearchService : ISearchService
    {
        private readonly IRepository<Product> _productReposity;

        public SearchService(IRepository<Product> productRepository)
        {
            _productReposity = productRepository;
        }

        public ICollection<Product> GetProductsByName(string name)
        {
            return _productReposity.Get(filter: x => x.ProName.Contains(name) && x.ProStatus == true).Take(5).ToList();
        }
        public ICollection<Product> GetProductsByPrice(double number)
        {
            double up, down = 0;
            up = number + 1000000;
            down = number - 1000000;
            ICollection<Product> products = _productReposity.Get(
                filter: x => x.ProSalePrice.HasValue ? (x.ProSalePrice < up && x.ProSalePrice > down) : (x.ProRetailPrice < up && x.ProRetailPrice > down)).Take(5).ToList();
            return products;
        }
    }
}
