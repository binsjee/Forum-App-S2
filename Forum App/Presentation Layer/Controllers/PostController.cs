using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Presentation_Layer.Converters;
using Microsoft.AspNetCore.Mvc;
using Forum_App.Models.Data;
using Presentation_Layer.ViewModels;
using Forum_App.Containers;
using Presentation_Layer.ViewModelConverters;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Presentation_Layer.Controllers
{
    public class PostController : Controller
    {
        private readonly PostVMConverter vmconverter = new PostVMConverter();
        private readonly PostContainer Container;
        private readonly ReplyVMConverter replyvmconverter = new ReplyVMConverter();
        private readonly ReplyContainer replyContainer;

        public PostController(PostContainer postcontainer, ReplyContainer replycontainer)
        {
            this.Container = postcontainer;
            this.replyContainer = replycontainer;
        }
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("User") != null)
            {
                AccountDetailVM account = new AccountDetailVM();
                account = JsonConvert.DeserializeObject<AccountDetailVM>(HttpContext.Session.GetString("User"));
                PostViewModel vm = new PostViewModel();
                List<Post> posts = new List<Post>();
                posts = Container.GetAll();
                //List<PostDetailVM> vms = new List<PostDetailVM>();
                vm.PostViewModels = vmconverter.ModelsToViewModels(posts);
                vm.account = account;
                return View(vm);
            }
            return RedirectToAction("Index", "Login");

        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CreatePost(PostDetailVM vm)
        {
            if (HttpContext.Session.GetInt32("User") != null)
            {
                Post post = vmconverter.ViewModelToModel(vm);
                Container.Insert(post);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Login");
        }
        public IActionResult Detail(int postID)
        {
            if (HttpContext.Session.GetInt32("User") != null)
            {
                //AccountDetailVM account = new AccountDetailVM();
                //account = JsonConvert.DeserializeObject<AccountDetailVM>(HttpContext.Session.GetString("User"));
                PostDetailVM vm = new PostDetailVM();
                Post post = Container.GetById(postID);
                post.Replies = replyContainer.GetAll();
                HttpContext.Session.SetString("Id", JsonConvert.SerializeObject(post.Id));
                vm = vmconverter.ModelToViewModel(post);
                //vm.account = account;
                return View(vm);
            }
            return RedirectToAction("Index", "Login");
        }

        public IActionResult Delete(int id)
        {
            Post p = new Post();
            p = Container.GetById(id);
            Container.Delete(p);
            return RedirectToAction("Index");
        }

    }
}
