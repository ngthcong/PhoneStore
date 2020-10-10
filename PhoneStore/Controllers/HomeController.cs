using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneStore.Interfaces.Services;
using PhoneStore.Models;
using PhoneStore.Models.FormModel;
using PhoneStore.Models.FormModel.User;
using PhoneStore.Models.Response;
using PhoneStore.Models.ViewModel;

namespace PhoneStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public HomeController(IProductService service, IUserService userService)
        {
            _productService = service;
            _userService = userService;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
