using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Form_Template.Data;
using Form_Template.Data.Repository;
using Form_Template.Models;
using Form_Template.ViewModels;
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
            var account = _repo.GetAllAccounts();

            return View(account);
        }

        public IActionResult Details(int id)
        {
            var account = _repo.GetAccount(id);

            return View(account);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View(new AccountModel());
            }
            else
            {
                var account = _repo.GetAccount((int)id);
                return View(new AccountModel
                {
                    Id = account.Id,
                    Email = account.Email,
                    UserName = account.UserName,
                    Password = account.Password,
                    FirstName = account.FirstName,
                    LastName = account.LastName,
                    Age = account.Age,
                    Gender = account.Gender,
                    MarriedStatus = account.MarriedStatus,
                    StreetAddress = account.StreetAddress,
                    AptSuite = account.AptSuite,
                    City = account.City,
                    State = account.State,
                    ZipCode = account.ZipCode,
                    Phone = account.Phone,

                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit (Account vm)
        {
            var account = new Account
            {
                Id = vm.Id,
                Email = vm.Email,
                UserName = vm.UserName,
                Password = vm.Password,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                StreetAddress = vm.StreetAddress,
                State = vm.State,
                City = vm.City,
                ZipCode = vm.ZipCode,
                Phone = vm.Phone,
                AptSuite = vm.AptSuite,
                Age = vm.Age,
                MarriedStatus = vm.MarriedStatus,
                Gender = vm.Gender,
            };

            if (account.Id > 0)
                _repo.UpdateAccount(account);
            else
                _repo.AddAccount(account);

            if (await _repo.SaveChangesAsync())
                RedirectToAction("Index");
            else
                return View(account);


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            _repo.RemoveAccount(id);
            await _repo.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
