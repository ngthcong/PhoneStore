using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ClosedXML.Excel;
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
            return View(_adminProdcutService.GetVariant(vid));
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
            Account oldAccount = _userService.GetUserByEmail(account.AccEmail);
            if (oldAccount == null)
            {
                _userService.CreateAccount(account);
                return Ok(new { status = 200 });
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
        [HttpPost]
        public IActionResult UpdateVariant(VariantModel vm)
        {
            _productService.UpdateVariant(vm);
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
            Invoice confirmedInvoice = _adminInvoiceService.ConfirmOrder(invoice);
            if (confirmedInvoice == null)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            Product oldProduct = _productService.GetProduct(product.ProId);
            if (oldProduct.ProStatus.Value == false && product.ProStatus.Value == true)
            {
                if (oldProduct.ProVariant.Count == 0 || oldProduct.ProVariant.Where(x => x.VarStatus.Value == true).Count() == 0)
                {
                    Response<string> ress = new Response<string>()
                    {
                        IsSuccess = false,
                        Code = "200",
                        Message = "Sản phẩm phải có ít nhất một phiên bản còn hoạt động"
                    };
                    return Ok(ress);
                }
            }


            Product newProduct = _productService.Update(product);
            if (newProduct == null)
            {
                return NotFound();
            }
            Response<string> res = new Response<string>()
            {
                IsSuccess = true,
                Code = "200",
                Message = "Cập nhật thành công"
            };
            return Ok(res);
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
        public IActionResult Report()
        {
            return View();
        }
        public IActionResult InvoiceReport(int m)
        {
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            ICollection<Invoice> invoiceList;
            int month = 0;
            if (m == 1)
            {
                month = DateTime.Now.Month;
            }
            else
            {
                month = DateTime.Now.Month - 1;
            }
            invoiceList = _adminInvoiceService.GetConfirmedInvoiceByMounth(month);
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    IXLWorksheet worksheet = workbook.Worksheets.Add("Báo cáo");

                    worksheet.Cell(1, 1).Value = "STT";
                    worksheet.Cell(1, 1).Style.Fill.BackgroundColor = XLColor.Cyan;

                    worksheet.Cell(1, 2).Value = "Mã hoá đơn";
                    worksheet.Cell(1, 2).Style.Fill.BackgroundColor = XLColor.Cyan;
                    worksheet.Cell(1, 3).Value = "Tên khách hàng";
                    worksheet.Cell(1, 3).Style.Fill.BackgroundColor = XLColor.Cyan;
                    worksheet.Cell(1, 4).Value = "Ngày tạo";
                    worksheet.Cell(1, 4).Style.Fill.BackgroundColor = XLColor.Cyan;
                    worksheet.Cell(1, 5).Value = "Ngày duyệt";
                    worksheet.Cell(1, 5).Style.Fill.BackgroundColor = XLColor.Cyan;
                    worksheet.Cell(1, 6).Value = "Số sản phẩm";
                    worksheet.Cell(1, 6).Style.Fill.BackgroundColor = XLColor.Cyan;
                    worksheet.Cell(1, 7).Value = "Tổng tiền";
                    worksheet.Cell(1, 7).Style.Fill.BackgroundColor = XLColor.Cyan;


                    worksheet.Cell(1, 10).Value = "Tổng hoá đơn";
                    worksheet.Cell(1, 10).Style.Fill.BackgroundColor = XLColor.Cyan;
                    worksheet.Cell(1, 11).Value = "Tổng sản phẩm";
                    worksheet.Cell(1, 11).Style.Fill.BackgroundColor = XLColor.Cyan;
                    worksheet.Cell(1, 12).Value = "Tổng lợi nhuận";
                    worksheet.Cell(1, 12).Style.Fill.BackgroundColor = XLColor.Cyan;
                    worksheet.Row(1).Style.Font.Bold = true;

                    int index = 1;
                    double totalIncome = 0;
                    int totalQty = 0;
                    foreach (Invoice item in invoiceList.OrderByDescending(x => x.DateCreated))
                    {
                        double total = 0;
                        int qty = 0;


                        foreach (InvoiceDetail detail in item.InvoiceDetail)
                        {

                            qty += detail.ProQty.Value;
                            total += detail.ProPrice.Value * detail.ProQty.Value;

                        }
                        totalIncome += total;
                        totalQty += qty;
                        worksheet.Cell(index + 1, 1).Value = index;
                        worksheet.Cell(index + 1, 2).Value = item.InvId;
                        worksheet.Cell(index + 1, 3).Value = item.InvCusName;

                        worksheet.Cell(index + 1, 4).Value = item.DateCreated;
                        worksheet.Cell(index + 1, 5).Value = item.InvDate;
                        worksheet.Cell(index + 1, 6).Value = qty;
                        worksheet.Cell(index + 1, 7).Value = total;

                        index++;
                    }

                    worksheet.Cell(2, 10).Value = invoiceList.Count();
                    worksheet.Cell(2, 11).Value = totalQty;
                    worksheet.Cell(2, 12).Value = totalIncome;




                    worksheet.Columns().AdjustToContents();
                    worksheet.Rows().AdjustToContents();


                    string fileName = "BaoCaoThang_" + month + ".xlsx";
                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(content, contentType, fileName);
                    }
                }
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        public IActionResult ProductReport()
        {
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = "BaoCaoSanPham.xlsx";
            ICollection<Product> productList = _adminProdcutService.GetAllProduct();
            try
            {
                using (var workbook = new XLWorkbook())
                {

                    IXLWorksheet worksheet = workbook.Worksheets.Add("Báo cáo");

                    worksheet.Cell(1, 1).Value = "STT";
                    worksheet.Cell(1, 1).Style.Fill.BackgroundColor = XLColor.Cyan;
                    worksheet.Cell(1, 2).Value = "Mã sản phẩm";
                    worksheet.Cell(1, 2).Style.Fill.BackgroundColor = XLColor.Cyan;
                    worksheet.Cell(1, 3).Value = "Tên sản phẩm";
                    worksheet.Cell(1, 3).Style.Fill.BackgroundColor = XLColor.Cyan;
                    worksheet.Cell(1, 4).Value = "Màu";
                    worksheet.Cell(1, 4).Style.Fill.BackgroundColor = XLColor.Cyan;
                    worksheet.Cell(1, 5).Value = "Số lượng";
                    worksheet.Cell(1, 5).Style.Fill.BackgroundColor = XLColor.Cyan;
                    worksheet.Cell(1, 6).Value = "Ngày thêm";
                    worksheet.Cell(1, 6).Style.Fill.BackgroundColor = XLColor.Cyan;
                    worksheet.Cell(1, 7).Value = "Tình trạng";
                    worksheet.Cell(1, 7).Style.Fill.BackgroundColor = XLColor.Cyan;
                    worksheet.Cell(1, 8).Value = "Giá bán";
                    worksheet.Cell(1, 8).Style.Fill.BackgroundColor = XLColor.Cyan;
                    worksheet.Cell(1, 9).Value = "Giá khuyến mãi";
                    worksheet.Cell(1, 9).Style.Fill.BackgroundColor = XLColor.Cyan;


                    int index = 1;
                    foreach (Product item in productList)
                    {

                        foreach (ProVariant detail in item.ProVariant)
                        {

                            worksheet.Cell(index + 1, 1).Value = index;
                            worksheet.Cell(index + 1, 2).Value = item.ProId;
                            worksheet.Cell(index + 1, 3).Value = item.ProName;
                            worksheet.Cell(index + 1, 4).Value = detail.VarColor;
                            worksheet.Cell(index + 1, 5).Value = detail.VarQty;
                            worksheet.Cell(index + 1, 6).Value = detail.DateCreated;
                            if (detail.VarStatus == true)
                                worksheet.Cell(index + 1, 7).Value = "Đang bán";
                            else
                                worksheet.Cell(index + 1, 7).Value = "Ngừng bán";
                            worksheet.Cell(index + 1, 8).Value = item.ProRetailPrice;
                            worksheet.Cell(index + 1, 9).Value = item.ProSalePrice;
                            index++;
                        }




                    }
                    worksheet.Columns().AdjustToContents();
                    worksheet.Rows().AdjustToContents();
                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(content, contentType, fileName);
                    }
                }
            }
            catch (Exception ex)
            {
                return NotFound();
            }
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
