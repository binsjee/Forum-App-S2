using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum_App.Containers;
using Forum_App.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using Presentation_Layer.ViewModelConverters;
using Presentation_Layer.ViewModels;

namespace Presentation_Layer.Controllers
{
    public class ReplyController : Controller
    {
        private readonly ReplyVMConverter vmconverter = new ReplyVMConverter();
        private readonly ReplyContainer replyContainer;
        public ReplyController(ReplyContainer container)
        {
            this.replyContainer = container;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            return View();
        }
        public IActionResult Create(ReplyDetailVM vm)
        {
            if (HttpContext.Session.GetInt32("User") != null)
            {
                Reply reply = vmconverter.ViewModelToModel(vm);
                Account account = new Account();
                account = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("User"));
                int accountID = account.Id;
                int postID = JsonConvert.DeserializeObject<int>(HttpContext.Session.GetString("Id"));
                reply.PostId = postID;
                reply.AccountId = accountID;
                reply.Username = account.Username;
                replyContainer.Insert(reply);
                //return RedirectToAction("Detail", new RouteValueDictionary(new { controller = "Post", action = "Detail", Id = postID }));
                return Redirect("~/Post/Detail/?postID=" + postID);
            }
            return RedirectToAction("Index", "Login");
        }
        public IActionResult ShowReplies()
        {
            ReplyViewModel vm = new ReplyViewModel();
            List<Reply> replies = new List<Reply>();
            replies = replyContainer.GetAll();
            vm.replyVMS = vmconverter.ModelsToViewModels(replies);
            return View(vm);
        }
        public IActionResult LeaveReply(int postID)
        {
            ReplyDetailVM vm = new ReplyDetailVM();
            vm.PostId = postID;
            if (HttpContext.Session.GetInt32("User") != null)
            {
                return View("Create");
            }
            return RedirectToAction("Index", "Login");
        }
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetInt32("User") != null)
            {
                Account account = new Account();
                account = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("User"));
                if (account.Administrator)
                {
                    Reply r = new Reply();
                    r = replyContainer.GetById(id);
                    replyContainer.Delete(r);
                    int postID = JsonConvert.DeserializeObject<int>(HttpContext.Session.GetString("Id"));
                    return Redirect("~/Post/Detail/?postID=" + postID);
                }
                return RedirectToAction("Index", "Login");
            }
            return RedirectToAction("Index", "Login");
        }
    }
}
