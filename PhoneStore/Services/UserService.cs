using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PhoneStore.CustomHandler;
using PhoneStore.Data;
using PhoneStore.Interfaces;
using PhoneStore.Interfaces.Repository;
using PhoneStore.Interfaces.Services;
using PhoneStore.Models.FormModel;
using PhoneStore.Models.FormModel.User;
using PhoneStore.Models.Response;
using PhoneStore.Models.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PhoneStore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;



        public UserService(IUserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;

        }

        public bool CheckUserLogin(int aid)
        {
            var _acc = GetUser(aid);
            bool _isValid = _userRepo.CheckAccountStatus(aid);
            if (_acc == null || !_isValid)
            {
                return false;
            }
            else
            {
                return true;

            }
        }


        public Account GetUser(int aid)
        {
            return _userRepo.GetUser(aid);
        }

        public Response<string> Login(LoginModel model, HttpContext httpContext)
        {
            Account _acc = _userRepo.GetAccountByEmail(model);

            Response<string> response = new Response<string>();
            if (_acc == null)
            {
                response.IsSuccess = false;
                response.Code = "401";
                response.Message = "Email hoặc mật khẩu không đúng";
            }
            else
            {
                if (_acc.AccStatus.Value)
                {
                    if (_acc.AccRoleId == 1)
                    {
                        if (_acc.AccPass == model.Pass)
                        {
                            GenerateCookie(_acc.AccId, _acc.AccRoleId.Value, httpContext);
                            response.IsSuccess = true;
                            response.Code = "200";
                            response.Message = "Đăng nhập thành công";
                            response.Data = "/admin/index";
                        }
                        else
                        {
                            response.IsSuccess = false;
                            response.Code = "401";
                            response.Message = "Email hoặc mật khẩu không đúng";
                        }
                    }
                    else
                    {
                        string passWord = Encrypt.EncryptPassword(model.Pass, _acc.AccSalt);
                        if (_acc.AccPass == passWord)
                        {
                            GenerateCookie(_acc.AccId, _acc.AccRoleId.Value, httpContext);
                            response.IsSuccess = true;
                            response.Code = "200";
                            response.Message = "Đăng nhập thành công";
                            if (_acc.AccRoleId == 4)
                                response.Data = "/home/index";
                            else
                                response.Data = "/admin/index";
                        }
                        else
                        {
                            response.IsSuccess = false;
                            response.Code = "401";
                            response.Message = "Email hoặc mật khẩu không đúng";
                        }
                    }
                }
                else
                {
                    response.IsSuccess = false;
                    response.Code = "401";
                    response.Message = "Tài khoản đã bị vô hiệu hoá";
                }

            }
            return response;
        }

        public void GenerateCookie(int aid, int role, HttpContext httpContext)
        {
            var userClaims = new List<Claim>()
                            {
                                //new Claim("Email", em.Email),
                                new Claim(ClaimTypes.NameIdentifier, aid.ToString()),
                                //new Claim(ClaimTypes.Email, em.Email),
                                new Claim(ClaimTypes.Role, role.ToString())
                            };
            var userIdentity = new ClaimsIdentity(userClaims, "User Identity");
            var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });

            int time = role > 3 ? 43200 : 30;

            httpContext.SignInAsync(userPrincipal, new AuthenticationProperties { ExpiresUtc = DateTime.Now.AddMinutes(time) });
        }

        public Response<string> Signup(SignupModel model, HttpContext httpContext)
        {
            if (model.RePass != model.AccPass)
            {
                Response<string> response = new Response<string>()
                {
                    IsSuccess = true,
                    Code = "200",
                    Message = "Mật khẩu nhập lại sai",
                };
                return response;
            }
            else
            {
                string salt = Encrypt.GetRandomSalt();
                string hashPassword = Encrypt.EncryptPassword(model.AccPass, salt);
                Account newAcc = _mapper.Map<Account>(model);
                newAcc.AccSalt = salt;
                newAcc.AccPass = hashPassword;
                newAcc.AccStatus = true;
                newAcc.AccRoleId = 4;
                newAcc.DateCreated = DateTime.Now;
                _userRepo.CreateAccount(newAcc);
                _userRepo.SaveChanges();
                Account createdAccount = _userRepo.GetUser(newAcc.AccId);
                GenerateCookie(createdAccount.AccId, createdAccount.AccRoleId.Value, httpContext);
                Response<string> response = new Response<string>()
                {
                    IsSuccess = true,
                    Code = "200",
                    Message = "Tạo tài khoản thành công",
                    Data = "/home/index"
                };
                return response;
            }
        }
    }
}
