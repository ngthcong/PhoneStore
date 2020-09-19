using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Models.ViewModel.Cart
{
    public class VariantCartModel
    {

        public int VarId { get; set; }
        public int? ProId { get; set; }
        public string VarColor { get; set; }
        public string VarColorIcon { get; set; }

    }
}
