using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneStore.Data;
using PhoneStore.Interfaces.Services;
using PhoneStore.Models;
using PhoneStore.Models.FormModel;
using PhoneStore.Models.FormModel.User;
using PhoneStore.Models.Response;
using PhoneStore.Models.ViewModel;
using PhoneStore.Models.ViewModel.User;

namespace PhoneStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly IAddressService _addressService;

        public HomeController(IProductService service, IUserService userService, IAddressService addressService)
        {
            _productService = service;
            _userService = userService;
            _addressService = addressService;
        }

        public IActionResult Index()
        {
            IndexViewModel index = new IndexViewModel()
            {
                accessories = _productService.GetProductsByGroup(2).Take(12),
                phones = _productService.GetProductsByGroup(1).Take(12),
                laptops = _productService.GetProductsByGroup(3).Take(12),
            };


            return View(index);
        }
     

        public IActionResult Privacy()
        {
            return View();
        }

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
                    return Redirect(Url.Action("Index", "Home"));
                else
                    return View();
            }

        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            Response<string> res = _userService.Login(model, HttpContext);
            return new JsonResult(res);
        }
        public IActionResult Signup()
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
                    return Redirect(Url.Action("Index", "Home"));
                else
                    return View();
            }

        }
        [HttpPost]
        public IActionResult Signup(SignupModel model)
        {
            if (!ModelState.IsValid)
            {
                Response res = new Response()
                {
                    IsSuccess = true,
                    Code = "200",
                    Message = "Mời bạn điền đầy đủ thông tin"
                };
                return new JsonResult(res);
            }
            else
            {
                Response<string> res = _userService.Signup(model, HttpContext);
                return new JsonResult(res);
            }
        }


        public IActionResult AccountInfo()
        {
            var user = User as ClaimsPrincipal;
            string userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
           
            if (userId == null)
                return View();
            else
            {
                bool _isvalid = _userService.CheckUserLogin(Int32.Parse(userId));
                if (_isvalid)
                {
                    AccountViewModel accountView = new AccountViewModel()
                    {
                        Account = _userService.GetUserInfo(Int32.Parse(userId)),
                        AddressCity = _addressService.GetCities(),
                        AddressDistrict = _addressService.GetDistricts(),
                        AddressWard = _addressService.GetWards()
                    };
                    return View(accountView);
                }
                else
                    return View();
            }


        }
        [HttpPost]
        public IActionResult UpdateInfo(Account account)
        {
            var user = User as ClaimsPrincipal;
            string userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return NotFound();
            Account oldAccount = _userService.GetUser(Int16.Parse(userId));
            if (oldAccount == null)
                return NotFound();
            _userService.UpdateAccount(oldAccount, account);
            return Ok();
        }



        public IActionResult Logout()
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
