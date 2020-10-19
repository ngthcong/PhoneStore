using PhoneStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        ICollection<AddressCity> GetCities();
        ICollection<AddressDistrict> GetDistricts();
        ICollection<AddressWard> GetWards();
    }
}
