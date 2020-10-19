using Microsoft.AspNetCore.Http;
using PhoneStore.Data;
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
        Account GetUser(int aid);
        Account GetUserInfo(int aid);
        Account GetUserByEmail(string email);
        bool CheckUserLogin(int aid);
        ICollection<Account> GetAllEmployees();
        ICollection<Account> GetAllAccount();
        void GenerateCookie(int aid, int role, HttpContext httpContext);
        void CreateAccount(Account account);
        void UpdateAccount(Account oldAccount, Account newAccount);
    }
}
