using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forum_App.Models.Data;
using Forum_App.Containers;
using Presentation_Layer.ViewModelConverters;
using Presentation_Layer.ViewModels;
using Presentation_Layer;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Presentation_Layer.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountVMConverter vmConverter = new AccountVMConverter();
        private readonly AccountContainer accountContainer;

        public AccountController(AccountContainer container)
        {
            this.accountContainer = container;
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult RegisterAccount(AccountDetailVM vm)
        {
            Account account = vmConverter.ViewModelToModel(vm);
            accountContainer.Insert(account);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("User") != null)
            {
                AccountDetailVM user = new AccountDetailVM();
                user = JsonConvert.DeserializeObject<AccountDetailVM>(HttpContext.Session.GetString("User"));
                return View(user);
            }
            return RedirectToAction("Index", "Login");
        }
        public IActionResult Profile(int id)
        {
            AccountDetailVM account = new AccountDetailVM();
            account = vmConverter.ModelToViewModel(accountContainer.GetById(id));
            return View(account);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
