using Microsoft.EntityFrameworkCore;
using PhoneStore.CustomHandler;
using PhoneStore.Data;
using PhoneStore.Interfaces.Repository;
using PhoneStore.Models.FormModel;
using PhoneStore.Models.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly PhoneStoreDBContext _context;

        public UserRepo(PhoneStoreDBContext context)
        {
            _context = context;
        }

        public bool CheckAccountStatus(int aid)
        {
            
            return _context.Account.Where(i => i.AccId == aid).Select(i => i.AccStatus).FirstOrDefault().Value;
        }

        public void CreateAccount(Account newacc)
        {
             _context.Account.Add(newacc);
        }

        public Account GetAccountByEmail(LoginModel model)
        {
            return _context.Account.Where(i => i.AccEmail == model.Email).FirstOrDefault();
        }

        public Account GetUser(int aid)
        {
            return _context.Account.Where(i => i.AccId == aid).FirstOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
