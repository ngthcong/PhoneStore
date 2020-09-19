using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneStore.CustomHandler;
using PhoneStore.Data;
using PhoneStore.Interfaces;
using PhoneStore.Interfaces.Services;
using PhoneStore.Models;
using PhoneStore.Models.FormModel;
using PhoneStore.Models.Response;
using PhoneStore.Services;

namespace PhoneStore.Controllers
{
    [Authorize(Roles = "1,2,3")]
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductRepo _productRepo;
        private readonly IUserService _userService;

        public AdminController(IProductService productService, IProductRepo productRepo, IUserService userService)
        {
            _productService = productService;
            _productRepo = productRepo;
            _userService = userService;
        }
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }
        public IActionResult AddPhone(ProductModel p, PhoneModel spec)
        {
           
            return new JsonResult(_productService.AddProductAsync<PhoneModel>(p, spec));
        }
        public IActionResult AddLaptop(ProductModel p, LaptopModel spec)
        {
            
            return new JsonResult(_productService.AddProductAsync<LaptopModel>(p, spec));
        }
        public IActionResult AddHeadPhone(ProductModel p, HeadPhoneModel spec)
        {
            
            return new JsonResult(_productService.AddProductAsync<HeadPhoneModel>(p, spec));
        }
        public IActionResult AddPowerBank(ProductModel p, PowerBankModel spec)
        {
            
            return new JsonResult(_productService.AddProductAsync<PowerBankModel>(p, spec));
        }
        public IActionResult AddCharger(ProductModel p, ChargerModel spec)
        {
            
            return new JsonResult(_productService.AddProductAsync<ChargerModel>(p, spec));
        }

        public IActionResult AddVariant(int pid)
        {
            ProtNameViewModel model = _productService.GetProName(pid);
            return View(model);
        }
        [HttpPost]
        public IActionResult AddVariant(VariantModel vm)
        {
            _productService.AddVariant(vm);
            return Ok();
        }

        public IActionResult AddDescription(int pid)
        {
            ProtNameViewModel model = _productService.GetProName(pid);
            return View(model);
        }
        [HttpPost]
        public IActionResult UploadDescription(DescriptionModel des)
        {
            _productService.AddDescription(des);
            return Ok();
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            var user = User as ClaimsPrincipal;
            string userId = user.FindFirstValue(ClaimTypes.NameIdentifier);


            if (userId == null)
            {
                return View();
            }
            else
            {
                bool _isvalid = _userService.CheckUserLogin(Int32.Parse(userId));
                if (_isvalid)
                    return Redirect(Url.Action("Index", "Admin"));
                else
                    return View();
            }

        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            Response<string> res = _userService.Login(model, HttpContext);
            return new JsonResult(res);
        }
    }
}
