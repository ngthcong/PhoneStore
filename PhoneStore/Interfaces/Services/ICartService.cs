using PhoneStore.Models;
using PhoneStore.Models.FormModel;
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
        IEnumerable<ProductCookieModel> DeleteFromCart(int pid);
        Response<string> Checkout(CheckOutModel model);
        void SetCookies(string key, string value, int? expireTime);
        List<ProductCookieModel> GetCookies(string key);
        string JoinCookie(List<ProductCookieModel> model);
        CartViewModel GetCartProduct(int? aid);

        int CartProductCount();
        CartPriceViewModel GetCartPrice(List<CartItemViewModel> cartItems);
    }
}
