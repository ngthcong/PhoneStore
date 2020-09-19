using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Models.ViewModel
{
    public class VariantViewModel
    {
        public int VarId { get; set; }
        public string VarColor { get; set; }
        public string VarColorIcon { get; set; }

        public bool Selected { get; set; }
    
    }  
}
