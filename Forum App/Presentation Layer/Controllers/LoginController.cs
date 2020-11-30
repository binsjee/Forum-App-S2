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
using Microsoft.Extensions.Logging;
using Presentation_Layer.Logging;
using Microsoft.Docs.Samples;

namespace Presentation_Layer.Controllers
{
    public class LoginController : Controller
    {
        private readonly AccountVMConverter converter = new AccountVMConverter();
        private readonly AccountContainer accountContainer;
        private readonly ILogger _logger;
        public LoginController(AccountContainer container, ILoggerFactory logger)
        {
            _logger = logger.CreateLogger("MyCategory");
            this.accountContainer = container;
        }
        public void OnGet()
        {
            _logger.LogInformation("GET LoginContrller called.");
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(AccountDetailVM vm)
        {
            if (ModelState.IsValid)
            {
                vm = converter.ModelToViewModel(accountContainer.GetByName(converter.ViewModelToModel(vm)));
                if(vm.Id != 0)
                {
                    HttpContext.Session.SetString("User", JsonConvert.SerializeObject(vm));
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(vm);
        }
        public IActionResult Test(int id)
        {
            var routeInfo = ControllerContext.ToCtxString(id);

            _logger.Log(LogLevel.Information, LogEvents.TestItem, routeInfo);
            _logger.LogInformation(LogEvents.TestItem, routeInfo);

            return ControllerContext.MyDisplayRouteInfo();
        }
    }
}
