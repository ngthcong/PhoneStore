using PhoneStore.Data;
using PhoneStore.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly PhoneStoreDBContext _context;

        public AddressRepository(PhoneStoreDBContext context)
        {
            _context = context;
        }

        public ICollection<AddressCity> GetCities()
        {
            return _context.AddressCity.ToList();
        }

        public ICollection<AddressDistrict> GetDistricts()
        {
            return _context.AddressDistrict.ToList();
        }

        public ICollection<AddressWard> GetWards()
        {
            return _context.AddressWard.ToList();
        }
    }
}
