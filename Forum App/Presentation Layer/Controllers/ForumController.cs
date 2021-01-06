using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Presentation_Layer.Converters;
using Forum_App.Models.Data;
using Presentation_Layer.ViewModels;
using Forum_App.Containers;
using Presentation_Layer.ViewModelConverters;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Database_Layer.Interfaces;

namespace Presentation_Layer.Controllers
{
    public class ForumController : Controller
    {
        private readonly ForumVMConverter forumConverter = new ForumVMConverter();
        private readonly ForumContainer forumContainer;
        private readonly PostVMConverter postConverter = new PostVMConverter();
        private readonly PostContainer postContainer;
        private readonly AccountContainer accountContainer;
        private readonly AccountVMConverter accountConverter = new AccountVMConverter();
        public ForumController(ForumContainer forumcontainer, PostContainer postcontainer, AccountContainer accountcontainer)
        {
            this.forumContainer = forumcontainer;
            this.postContainer = postcontainer;
            this.accountContainer = accountcontainer;
        }
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("User") != null)
            {
                AccountDetailVM account = new AccountDetailVM();
                ForumVM vm = new ForumVM();
                List<Forum> forums = new List<Forum>();
                forums = forumContainer.GetAll();
                vm.Forums = forumConverter.ModelsToViewModels(forums);
                foreach (ForumDetailVM detailVM in vm.Forums)
                {
                    detailVM.Creator = accountConverter.ModelToViewModel(accountContainer.GetById(detailVM.CreatorID));
                }    
                return View(vm);
            }
            return RedirectToAction("Index", "Login");
        }
        public IActionResult Detail(int ForumID)
        {
            if(HttpContext.Session.GetInt32("User") != null)
            {
                ForumDetailVM vm = new ForumDetailVM();
                Forum forum = forumContainer.GetById(ForumID);
                forum.Posts = postContainer.GetAll();
                vm = forumConverter.ModelToViewModel(forum);
                return View(vm);
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpGet]
        public IActionResult Create()
        {
            if(HttpContext.Session.GetInt32("User") != null)
            {
                AccountDetailVM account = new AccountDetailVM();
                account = JsonConvert.DeserializeObject<AccountDetailVM>(HttpContext.Session.GetString("User"));
                if (account.Administrator)
                {
                    return View();
                }
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public IActionResult Create(ForumDetailVM vm)
        {
            if (HttpContext.Session.GetInt32("User") != null)
            {
                AccountDetailVM account = new AccountDetailVM();
                account = JsonConvert.DeserializeObject<AccountDetailVM>(HttpContext.Session.GetString("User"));
                Forum forum = forumConverter.ViewModelToModel(vm);
                forum.CreatorID = account.Id;
                forumContainer.Insert(forum);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Login");
        }
    }
}
