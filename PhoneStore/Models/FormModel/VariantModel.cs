using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Models
{
    public class VariantModel
    {
        public int? proId { get; set; }
        public string color { get; set; }
        public IFormFile proColorIcon { get; set; }
        public IFormFile[] proColorImage { get; set; }
        public double? proQty { get; set; }
        public bool? proStatus { get; set; }
    }
}
