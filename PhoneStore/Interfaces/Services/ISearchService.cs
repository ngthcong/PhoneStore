using PhoneStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Interfaces.Services
{
    public interface ISearchService
    {
        ICollection<Product> GetProductsByName(string name);
        ICollection<Product> GetProductsByPrice(double number);

    }
}
