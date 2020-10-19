using PhoneStore.Data;
using PhoneStore.Interfaces.Repositories;
using PhoneStore.Interfaces.Services;
using PhoneStore.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repository;

        public AddressService(IAddressRepository repository )
        {
            _repository = repository;
        }

        public ICollection<AddressCity> GetCities()
        {
           return _repository.GetCities();
        }

        public ICollection<AddressDistrict> GetDistricts()
        {
            return _repository.GetDistricts();
        }



        public ICollection<AddressWard> GetWards()
        {
            return _repository.GetWards();
        }

   
    }
}
