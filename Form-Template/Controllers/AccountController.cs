using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Form_Template.Data;
using Form_Template.Data.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Form_Template.Controllers
{
    public class AccountController : Controller
    {
        private AccountDbContext _ctx;
        private IRepository _repo;

        public AccountController (AccountDbContext ctx, IRepository repo)
        {
            _ctx = ctx;
            _repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var accounts = _repo.GetAllAccounts();

            return View();
        }

        public IActionResult Details()
        {
            return View();
        }



    }
}
