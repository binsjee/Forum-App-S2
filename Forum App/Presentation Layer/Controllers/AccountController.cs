using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forum_App.Models.Data;
using Forum_App.Containers;
using Presentation_Layer.ViewModelConverters;
using Presentation_Layer.ViewModels;

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
            return View("Index");
        }
    }
}
