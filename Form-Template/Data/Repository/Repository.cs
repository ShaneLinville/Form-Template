using Form_Template.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Form_Template.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly AccountDbContext _ctx;
  

        public Repository(AccountDbContext ctx)
        {
            _ctx = ctx;
         
        }

        public void AddAccount(Account account)
        {
            _ctx.Account.Add(account);
        }

        public void RemoveAccount(int Id)
        {
            _ctx.Account.Remove(GetAccount(Id));
        }

        public Account GetAccount(int id)
        {
            return _ctx.Account.FirstOrDefault(a => a.Id == id);
        }

        public List<Account> GetAllAccounts()
        {
            return _ctx.Account.OrderByDescending(a => a.Id).ToList();
        }

        public void UpdateAccount(Account account)
        {
            _ctx.Account.Update(account);
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _ctx.SaveChangesAsync() > 0)
            {
                return true;
            }

            return false;
        }



    }
}
