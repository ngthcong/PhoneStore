using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PhoneStore.Interfaces.Services;
using PhoneStore.Models.ViewModel;
using PhoneStore.Models.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PhoneStore.ViewComponents
{
    public class NavBarViewComponent : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hosting;
        private readonly IUserService _userService;
        private readonly ICartService _cartService;

        public NavBarViewComponent(IProductService productService,
            IUserService userService,
            ICartService cartService, 
            IMapper mapper, 
            IWebHostEnvironment hosting)
        {
            _productService = productService;
            _mapper = mapper;
            _hosting = hosting;
            _userService = userService;
            _cartService = cartService;
        }
        public IViewComponentResult Invoke()
        {
            var user = User as ClaimsPrincipal;
            string userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                
                HeaderViewModel model = _productService.GetMenu();
                
                model.cartCount = _cartService.CartProductCount();
                return View(model);
            }
            else
            {
                
                
                UserViewModel userModel = _userService.GetUserInfo(Int32.Parse(userId));
                HeaderViewModel model = _productService.GetMenu();
                model.user = userModel;
                model.cartCount = _cartService.CartProductCount();
                return View(model);
            }

        }
    }
}
