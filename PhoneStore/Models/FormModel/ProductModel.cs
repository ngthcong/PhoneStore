using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Models
{
    public class ProductModel
    {
        public string proName { get; set; }
        public int? proGroupId { get; set; }
        public int? proBrandId { get; set; }
        public int? ProTypeId { get; set; }
        public IFormFile proImageStream { get; set; }
        public double? proRetailPrice { get; set; }
        public double? proSalePrice { get; set; }
        //public bool? proVisible { get; set; }


    }
}
