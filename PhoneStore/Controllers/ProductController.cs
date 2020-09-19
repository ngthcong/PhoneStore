using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneStore.Interfaces.Services;
using PhoneStore.Models;
using PhoneStore.Models.FormModel;
using PhoneStore.Models.Response;
using PhoneStore.Models.ViewModel;

namespace PhoneStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _proService;
        private readonly ICartService _cartService;

        public ProductController(IProductService proService, ICartService cartService)
        {
            _proService = proService;
            _cartService = cartService;
        }
        public IActionResult ProductInfo(int pid)
        {
            return View(_proService.GetProductInfo(pid));
        }
        [HttpGet]
        public IActionResult VariantImage(int vid)
        {
            IEnumerable<ImageViewModel> images = _proService.GetProductImage(vid);
            Response<IEnumerable<ImageViewModel>> res = new Response<IEnumerable<ImageViewModel>>()
            {
                IsSuccess = true,
                Code = "200",
                Message = null,
                Data = images
            };
            return new JsonResult(res);
        }
        public IActionResult Product(int gid, int? tid, int? bid)
        {
            if (tid == null && bid == null)
            {
                PageinatedList<ProductViewModel> pages = PageinatedList<ProductViewModel>.CreateAsync(_proService.GetProducts(gid).AsQueryable(), 1, 12);
                return View(pages);
            }
            else if (tid != null && bid == null)
            {

                PageinatedList<ProductViewModel> pages = PageinatedList<ProductViewModel>.CreateAsync(_proService.GetProductsByType(gid, tid.Value).AsQueryable(), 1, 12);
                return View(pages);

            }
            else
            {
                PageinatedList<ProductViewModel> pages = PageinatedList<ProductViewModel>.CreateAsync(_proService.GetProductsByBrand(gid, bid.Value).AsQueryable(), 1, 12);
                return View(pages);
            }
        }

        public IActionResult Cart()
        {
            return View(_cartService.GetCartProduct());
        }
        [HttpPost]
        public IActionResult AddCart(int pid)
        {
            _cartService.AddToCart(pid);
            Response<string> res = new Response<string>()
            {
                IsSuccess = true,
                Code = "200",
                Message = null,
                Data = Url.Action("Cart", "Product")
            };
            return new JsonResult(res);
        }
        [HttpPost]
        public IActionResult ChangeCartProduct(int pid, bool change)
        {
            Response<string> res = new Response<string>();
            if (change)
            {
                _cartService.AddToCart(pid);

                res.IsSuccess = true;
                res.Code = "200";
                res.Message = null;
                res.Data = Url.Action("PartialCart", "Product");


            }
            else
            {
                _cartService.RemoveFromCart(pid);

                res.IsSuccess = true;
                res.Code = "200";
                res.Message = null;
                res.Data = Url.Action("PartialCart", "Product");


            }
            return new JsonResult(res);
        }
        [HttpPost]
        public IActionResult ChangeCartVariant(int pid, int vid)
        {
            Response<string> res = new Response<string>();
            _cartService.ChangeVariant(pid, vid);

            res.IsSuccess = true;
            res.Code = "200";
            res.Message = null;
            res.Data = Url.Action("PartialCart", "Product");



            return new JsonResult(res);
        }
        [HttpPost]
        public IActionResult Checkout(CheckOutModel model)
        {
            Response<string> res = new Response<string>();
            

            res.IsSuccess = true;
            res.Code = "200";
            res.Message = null;
            res.Data = Url.Action("PartialCart", "Product");



            return new JsonResult(res);
        }


        public IActionResult PartialCart()
        {
            return PartialView("_Cart", _cartService.GetCartProduct());
        }

        public IActionResult GetCites()
        {
            return new JsonResult(_proService.GetCities());
        }

        public IActionResult GetDistrict(int cid)
        {
            return new JsonResult(_proService.GetDistricts(cid));
        }
        public IActionResult GetWard(int did)
        {
            return new JsonResult(_proService.GetWards(did));
        }

    }
}
