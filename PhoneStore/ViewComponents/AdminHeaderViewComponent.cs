using Microsoft.AspNetCore.Mvc;
using PhoneStore.Data;
using PhoneStore.Interfaces.Services;
using PhoneStore.Models.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PhoneStore.ViewComponents
{
    public class AdminHeaderViewComponent : ViewComponent
    {
        private readonly IUserService _userService;

        public AdminHeaderViewComponent(IUserService userService)
        {
            _userService = userService;

        }

        public IViewComponentResult Invoke()
        {
            var user = User as ClaimsPrincipal;
            string userId = user.FindFirstValue(ClaimTypes.NameIdentifier);

            Account userModel = _userService.GetUser(Int32.Parse(userId));
            return View(userModel);
        }
    }
}
