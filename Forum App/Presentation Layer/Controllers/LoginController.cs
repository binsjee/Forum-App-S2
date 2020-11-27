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

namespace Presentation_Layer.Controllers
{
    public class LoginController : Controller
    {
        private readonly AccountVMConverter converter = new AccountVMConverter();
        public IActionResult Index()
        {
            return View();
        }
    }
}
