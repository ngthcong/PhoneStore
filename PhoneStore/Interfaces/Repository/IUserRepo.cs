using PhoneStore.Data;
using PhoneStore.Models.FormModel;
using PhoneStore.Models.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Interfaces.Repository
{
    public interface IUserRepo
    {
        Account GetUserAccount(LoginModel model);
        Account GetUserInfo(int aid);
        bool CheckAccountStatus(int aid);
        void CreateAccount(Account newacc);
        void SaveChanges();
    }
}
