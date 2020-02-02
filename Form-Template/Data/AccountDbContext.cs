using Form_Template.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Form_Template.Data
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext (DbContextOptions<AccountDbContext> options)
            : base (options)
        {

        }

       public DbSet<Account> Account { get; set; }
    }
}
