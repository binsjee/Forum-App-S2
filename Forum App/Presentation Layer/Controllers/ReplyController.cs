using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum_App.Containers;
using Forum_App.Models.Data;
using Microsoft.AspNetCore.Mvc;
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
            Reply reply = vmconverter.ViewModelToModel(vm);
            replyContainer.Insert(reply);
            return RedirectToAction("Detail", "Post");
        }
        public IActionResult ShowReplies()
        {
            ReplyViewModel vm = new ReplyViewModel();
            List<Reply> replies = new List<Reply>();
            replies = replyContainer.GetAll();
            vm.replyVMS = vmconverter.ModelsToViewModels(replies);
            return View(vm);
        }
        public IActionResult LeaveReply()
        {
            return View("Create");
        }
    }
}
