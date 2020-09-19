using PhoneStore.Models;
using PhoneStore.Models.Response;
using PhoneStore.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Interfaces.Services
{
    public interface ICartService
    {
        IEnumerable<ProductCookieModel> AddToCart(int pid);
        IEnumerable<ProductCookieModel> ChangeVariant(int pid, int vid);
        IEnumerable<ProductCookieModel> RemoveFromCart(int pid);
        void SetCookies(string key, string value, int? expireTime);
        List<ProductCookieModel> GetCookies(string key);
        string JoinCookie(List<ProductCookieModel> model);
        CartViewModel GetCartProduct();
        int CartProductCount();
        CartPriceViewModel GetCartPrice(List<CartItemViewModel> cartItems);
    }
}
