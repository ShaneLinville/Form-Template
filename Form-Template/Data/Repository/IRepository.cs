using Form_Template.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Form_Template.Data.Repository
{
    public interface IRepository
    {
        Account GetAccount(int Id);
        List<Account> GetAllAccounts();
        void AddAccount(Account account);
        void RemoveAccount(int Id);
        void UpdateAccount(Account account);

        Task<bool> SaveChangesAsync();

    }
}
