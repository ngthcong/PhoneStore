using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Models.ViewModel.User
{
    public class UserViewModel
    {
        public int AccId { get; set; }
        public string AccName { get; set; }
        public string AccEmail { get; set; }
        public string AccPhone { get; set; }
        public DateTime? AccBirthday { get; set; }
        public int? AccCityId { get; set; }
        public int? AccDistrictId { get; set; }
        public int? AccWardId { get; set; }
        public string AccAddressNumber { get; set; }
    }
}
