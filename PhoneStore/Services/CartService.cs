﻿using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.Language;
using Newtonsoft.Json;
using PhoneStore.CustomHandler;
using PhoneStore.Interfaces;
using PhoneStore.Interfaces.Services;
using PhoneStore.Models;
using PhoneStore.Models.Response;
using PhoneStore.Models.ViewModel;
using PhoneStore.Models.ViewModel.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PhoneStore.Services
{
    public class CartService : ICartService
    {
        private readonly IProductRepo _repo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hosting;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProductService _proService;
        private readonly IProductRepo _productRepo;

        public CartService(IProductRepo repo,
            IMapper mapper,
            IWebHostEnvironment hosting,
            IHttpContextAccessor httpContextAccessor,
            IProductService productService,
            IProductRepo productRepo
            )
        {
            _repo = repo;
            _mapper = mapper;
            _hosting = hosting;
            _httpContextAccessor = httpContextAccessor;
            _proService = productService;
            _productRepo = productRepo;
        }
        public IEnumerable<ProductCookieModel> AddToCart(int pid)
        {
            var _cookie = GetCookies("CartCookie");
            var _variant = _productRepo.GetProVariant(pid, true);
            if (_cookie == null)
            {

                string _productcookie = pid + "_" + _variant.First().VarId + "_1";
                SetCookies("CartCookie", _productcookie, 2);

            }
            else
            {
                //Tìm sản phẩm có sẵn
                if (_cookie.Where(i => i.pid == pid).Any())
                    _cookie.Where(i => i.pid == pid).Select(i => { i.qty += 1; return i; }).ToList();
                else
                {
                    //Thêm sản phẩm mới
                    ProductCookieModel _model = new ProductCookieModel()
                    {
                        pid = pid,
                        vid = _variant.First().VarId,
                        qty = 1
                    };
                    _cookie.Add(_model);
                }



                string _newCookie = JoinCookie(_cookie);
                SetCookies("CartCookie", _newCookie, 2);
            }


            return _cookie;

        }
        public IEnumerable<ProductCookieModel> ChangeVariant(int pid, int vid)
        {
            var _cookie = GetCookies("CartCookie");
            var _variant = _productRepo.GetProVariant(pid, true);
            if (_cookie.Where(i => i.pid == pid).Any())
                _cookie.Where(i => i.pid == pid).Select(i => { i.vid = vid; return i; }).ToList();
            string _newCookie = JoinCookie(_cookie);
            SetCookies("CartCookie", _newCookie, 2);
            return _cookie;
        }

        public int CartProductCount()
        {
            var cart = GetCartProduct();
            if (cart != null)
            {
                return cart.cartItem.Count();
            }
            else
            {
                return 0;
            }
        }

        public CartPriceViewModel GetCartPrice(List<CartItemViewModel> cartItems)
        {
            CartPriceViewModel cartPrice = new CartPriceViewModel()
            {
                temp = 0,
                discount = 0,
                total = 0
            };
            foreach (var item in cartItems)
            {
                cartPrice.temp += item.ProRetailPrice.Value * item.qty;
                if (item.ProSalePrice != null)
                {
                    cartPrice.discount += (item.ProRetailPrice.Value - item.ProSalePrice.Value) * item.qty;
                    cartPrice.total += item.ProSalePrice.Value * item.qty;
                }
                else
                {
                    cartPrice.total += item.ProRetailPrice.Value * item.qty;
                }
            }

            return cartPrice;
        }

        public CartViewModel GetCartProduct()
        {
            List<ProductCookieModel> _cookie = GetCookies("CartCookie");
            if (_cookie != null)
            {
                List<CartItemViewModel> products = new List<CartItemViewModel>();
                foreach (var item in _cookie)
                {
                    CartItemViewModel model = _mapper.Map<CartItemViewModel>(_repo.GetProductById(item.pid, true));
                    model.VariantList = _mapper.Map<IEnumerable<VariantViewModel>>(_repo.GetProVariant(item.pid, true));
                    if (model.VariantList.Where(i => i.VarId == item.vid).Any())
                    {
                        model.VariantList.Where(i => i.VarId == item.vid).Select(i => { i.Selected = true; return i; }).ToList();
                        model.varImage = model.VariantList.Where(i => i.VarId == item.vid).Select(i => i.VarColorIcon).SingleOrDefault(); ;
                    }
                    model.qty = item.qty;
                    products.Add(model);
                }
                CartViewModel cartModel = new CartViewModel()
                {
                    cartItem = products,
                    cartPrice = GetCartPrice(products),
                    cities = _proService.GetCities()
                };
                return cartModel;
            }
            else return null;

        }

        public List<ProductCookieModel> GetCookies(string key)
        {
            string cookie = _httpContextAccessor.HttpContext.Request.Cookies[key];
            List<ProductCookieModel> _listCookie = new List<ProductCookieModel>();
            if (cookie == null)
                return null;
            else
            {
                string[] _cookieValue = FileManager.StringSeparator(cookie, "|");
                foreach (string item in _cookieValue)
                {
                    string[] _product = FileManager.StringSeparator(item, "_");
                    ProductCookieModel model = new ProductCookieModel()
                    {
                        pid = Int32.Parse(_product[0]),
                        vid = Int32.Parse(_product[1]),
                        qty = Int32.Parse(_product[2])
                    };
                    _listCookie.Add(model);
                }
            }

            return _listCookie;
        }

        public string JoinCookie(List<ProductCookieModel> model)
        {
            string _cookie = null;
            for (int i = 0; i < model.Count(); i++)
            {
                if (i == model.Count() - 1)
                {
                    _cookie += model[i].pid + "_" + model[i].vid + "_" + model[i].qty;
                }
                else
                    _cookie += model[i].pid + "_" + model[i].vid + "_" + model[i].qty + "|";
            }
            return _cookie;
        }

        public IEnumerable<ProductCookieModel> RemoveFromCart(int pid)
        {
            var _cookie = GetCookies("CartCookie");

            if (_cookie != null)
            {
                //Tìm sản phẩm có sẵn
                if (_cookie.Where(i => i.pid == pid).Any())
                    _cookie.Where(i => i.pid == pid).Select(i =>
                    {
                        if (i.qty == 1)
                            return i;
                        else
                        {
                            i.qty -= 1;
                            return i;
                        }
                    }).ToList();
                string _newCookie = JoinCookie(_cookie);
                SetCookies("CartCookie", _newCookie, 2);
            }


            return _cookie;
        }

        public void SetCookies(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();
            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMonths(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMonths(1);
            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value, option);
        }
    }
}
