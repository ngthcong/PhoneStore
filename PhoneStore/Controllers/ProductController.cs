using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneStore.Data;
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
            IEnumerable<VarImages> images = _proService.GetProductImage(vid);
            Response<IEnumerable<VarImages>> res = new Response<IEnumerable<VarImages>>()
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
                PageinatedList<Product> pages = PageinatedList<Product>.CreateAsync(_proService.GetProductsByGroup(gid).AsQueryable(), 1, 12);
                return View(pages);
            }
            else if (tid != null && bid == null)
            {

                PageinatedList<Product> pages = PageinatedList<Product>.CreateAsync(_proService.GetProductsByType(gid, tid.Value).AsQueryable(), 1, 12);
                return View(pages);

            }
            else
            {
                PageinatedList<Product> pages = PageinatedList<Product>.CreateAsync(_proService.GetProductsByBrand(gid,null, bid.Value).AsQueryable(), 1, 12);
                return View(pages);
            }
        }

        public IActionResult Cart()
        {
            var user = User as ClaimsPrincipal;
            string userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return View(_cartService.GetCartProduct(null));
            }
            return View(_cartService.GetCartProduct(Int16.Parse(userId)));
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
        public IActionResult DeleteFromCart(int pid)
        {
            Response<string> res = new Response<string>();
            _cartService.DeleteFromCart(pid);

            res.IsSuccess = true;
            res.Code = "200";
            res.Message = null;
            res.Data = Url.Action("PartialCart", "Product");



            return new JsonResult(res);
        }
        [HttpPost]
        public IActionResult Checkout(CheckOutModel model)
        {
           
            var user = User as ClaimsPrincipal;
            string userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            model.CusId = userId == null ? (int?)null : Int16.Parse(userId);
            Response<string> res = _cartService.Checkout(model);
            res.Data = Url.Action("Cart", "Product");
            return new JsonResult(res);
        }


        public IActionResult PartialCart()
        {
            var user = User as ClaimsPrincipal;
            string userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return PartialView("_Cart", _cartService.GetCartProduct(null));
            }
            return PartialView("_Cart", _cartService.GetCartProduct(Int16.Parse(userId)));
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
