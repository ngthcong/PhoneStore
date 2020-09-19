using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Models.Response
{
    public class ProductCookieModel
    {
        public int pid { get; set; }
        public int vid { get; set; }
        public int qty { get; set; }
    }
    public class ListCookieProduct
    {
        public List<ProductCookieModel> listCookieProduct { get; set; }
    }
}
