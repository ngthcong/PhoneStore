using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneStore.CustomHandler;
using PhoneStore.Data;
using PhoneStore.Interfaces;
using PhoneStore.Interfaces.Services;
using PhoneStore.Models;
using PhoneStore.Models.FormModel;
using PhoneStore.Models.Response;
using PhoneStore.Models.ViewModel;
using PhoneStore.Models.ViewModel.InvoiceModel;
using PhoneStore.Models.ViewModel.ProductModel;
using PhoneStore.Services;

namespace PhoneStore.Controllers
{
    [Authorize(Roles = "1,2,3")]
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductRepo _productRepo;
        private readonly IUserService _userService;
        private readonly IAdminProductService _adminProdcutService;
        private readonly IAdminInvoiceService _adminInvoiceService;
        private readonly IAddressService _addressService;

        public AdminController(IProductService productService,
            IProductRepo productRepo,
            IUserService userService,
            IAdminProductService adminProductService,
            IAdminInvoiceService adminInvoiceService,
            IAddressService addressService)
        {
            _productService = productService;
            _productRepo = productRepo;
            _userService = userService;
            _adminProdcutService = adminProductService;
            _adminInvoiceService = adminInvoiceService;
            _addressService = addressService;
        }
        public IActionResult Index()
        {
            IndexModel Statistics = new IndexModel()
            {
                Products = _adminProdcutService.GetAllProduct(),
                Invoices = _adminInvoiceService.GetAllInvoice(),
                Accounts = _userService.GetAllAccount()
            };
            return View(Statistics);
        }
       
        public IActionResult ProductInfo(int pid)
        {
            return View(_adminProdcutService.GetProduct(pid));
        }
        public IActionResult VariantInfo(int vid)
        {
            return View(_adminProdcutService.GetVariant(vid));
        }
        public IActionResult ProductSpec(int pid)
        {
            
            return View(_adminProdcutService.GetProduct(pid));
        }
        
        public IActionResult UpdateVariant(int vid)
        {
            return View( _adminProdcutService.GetVariant(vid));
        }
        public IActionResult ProductList()
        {
            
            return View(_adminProdcutService.GetAllProduct());
        }
        public IActionResult Employees()
        {
            return View(_userService.GetAllEmployees());
        }
        public IActionResult InvoicePending()
        {
            return View(_adminInvoiceService.GetPendingInvoice());
        }
        public IActionResult InvoiceDetail(int id)
        {
            InvoiceDetailViewModel model = new InvoiceDetailViewModel()
            {
                Invoice = _adminInvoiceService.GetInvoice(id),
                Cities = _addressService.GetCities(),
                AddressDistricts = _addressService.GetDistricts(),
                AddressWards = _addressService.GetWards()
            };

            return View(model);
        }
        public IActionResult InvoiceList()
        {
            return View(_adminInvoiceService.GetAllInvoice());
        }

        public IActionResult AddProduct()
        {
            return View();
        }
        

        public IActionResult AddVariant(int pid)
        {
            ProtNameViewModel model = _productService.GetProName(pid);
            return View(model);
        }
        public IActionResult AddEmployee()
        {
            return View(_addressService.GetCities());
        }
        [HttpPost]
        public IActionResult AddEmployee(Account account)
        {
           Account oldAccount  = _userService.GetUserByEmail(account.AccEmail);
            if (oldAccount == null)
            {
                _userService.CreateAccount(account);
                return Ok(new {status = 200 });
            }
            else
            {
                return Ok(new { status = 409 });
            }
           

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

        [HttpPost]
        public IActionResult ConfirmOrder(Invoice invoice)
        {
          Invoice confirmedInvoice =   _adminInvoiceService.ConfirmOrder(invoice);
            if(confirmedInvoice == null)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
          Product newProduct =  _productService.Update(product);
            if (newProduct == null)
            {
                return NotFound();
            }
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
        public IActionResult Logout()
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Admin");
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            Response<string> res = _userService.Login(model, HttpContext);
            return new JsonResult(res);
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
    }
}
