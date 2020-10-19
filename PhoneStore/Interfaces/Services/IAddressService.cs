using PhoneStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Interfaces.Services
{
    public interface IAddressService
    {
        ICollection<AddressCity> GetCities();
        ICollection<AddressDistrict> GetDistricts();
        ICollection<AddressWard> GetWards();

    }
}
