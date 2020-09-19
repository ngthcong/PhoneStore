using Microsoft.AspNetCore.Http;
using PhoneStore.Models.FormModel;
using PhoneStore.Models.FormModel.User;
using PhoneStore.Models.Response;
using PhoneStore.Models.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PhoneStore.Interfaces.Services
{
    public interface IUserService
    {
        Response<string> Login(LoginModel model, HttpContext httpContext);
        Response<string> Signup(SignupModel model, HttpContext httpContext);
        UserViewModel GetUserInfo(int aid);
        bool CheckUserLogin(int aid);

        void GenerateCookie(int aid, string role, HttpContext httpContext);
    }
}
