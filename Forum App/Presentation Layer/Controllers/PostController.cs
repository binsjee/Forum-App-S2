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
using Database_Layer.Interfaces;

namespace Presentation_Layer.Controllers
{
    public class PostController : Controller
    {
        private readonly PostVMConverter vmconverter = new PostVMConverter();
        private readonly PostContainer Container;
        private readonly ReplyVMConverter replyvmconverter = new ReplyVMConverter();
        private readonly ReplyContainer replyContainer;
        private readonly ForumVMConverter forumvmconverter = new ForumVMConverter();
        private readonly ForumContainer forumContainer;
        private readonly IPostUpdateContext postUpdate;

        public PostController(PostContainer postcontainer, ReplyContainer replycontainer, ForumContainer forumcontainer, IPostUpdateContext update)
        {
            this.Container = postcontainer;
            this.replyContainer = replycontainer;
            this.forumContainer = forumcontainer;
            this.postUpdate = update;
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
                int forumId = JsonConvert.DeserializeObject<int>(HttpContext.Session.GetString("forumId"));
                //List<PostDetailVM> vms = new List<PostDetailVM>();
                vm.PostViewModels = vmconverter.ModelsToViewModels(posts);
                vm.currentForumId = forumId;
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
                AccountDetailVM account = new AccountDetailVM();
                account = JsonConvert.DeserializeObject<AccountDetailVM>(HttpContext.Session.GetString("User"));
                Post post = vmconverter.ViewModelToModel(vm);
                post.AccountId = account.Id;
                int forumId = JsonConvert.DeserializeObject<int>(HttpContext.Session.GetString("forumId"));
                post.ForumId = forumId;
                Container.Insert(post);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Login");
        }
        public IActionResult Detail(int postID)
        {
            if (HttpContext.Session.GetInt32("User") != null)
            {
                AccountDetailVM account = new AccountDetailVM();
                account = JsonConvert.DeserializeObject<AccountDetailVM>(HttpContext.Session.GetString("User"));
                PostDetailVM vm = new PostDetailVM();
                Post post = Container.GetById(postID);
                post.Replies = replyContainer.GetAll();
                HttpContext.Session.SetString("Id", JsonConvert.SerializeObject(post.Id));
                vm = vmconverter.ModelToViewModel(post);
                vm.account = account;
                return View(vm);
            }
            return RedirectToAction("Index", "Login");
        }

        public IActionResult Delete(int id)
        {          
            Post p = Container.GetById(id);
            Container.Delete(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int postID)
        {
            if(HttpContext.Session.GetInt32("User") != null)
            {
                PostDetailVM vm = new PostDetailVM();
                vm.Id = postID;
                vm.Replies = replyvmconverter.ModelsToViewModels(replyContainer.GetAll());
                vm = vmconverter.ModelToViewModel(Container.GetById(vm.Id));
                return View(vm);
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public IActionResult Edit(PostDetailVM newVm)
        {
            Account account = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("User"));
            PostDetailVM vm = new PostDetailVM();
            vm = vmconverter.ModelToViewModel(Container.GetById(newVm.Id));
            Post post = vmconverter.ViewModelToModel(vm);
            post = vmconverter.ViewModelToModel(newVm);
            post.Update(postUpdate);
            return RedirectToAction("Detail", new { PostID = post.Id});
        }
    }
}
