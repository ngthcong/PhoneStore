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

        public ICollection<Product> GetProducts(string name)
        {
            return _productReposity.Get(filter: x => x.ProName.Contains(name) && x.ProStatus == true);
        }
    }
}
