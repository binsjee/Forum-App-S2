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

namespace Presentation_Layer.Controllers
{
    public class PostController : Controller
    {
        private readonly PostVMConverter vmconverter = new PostVMConverter();
        private readonly PostContainer Container;
        //private readonly ReplyVMConverter replyvmconverter = new ReplyVMConverter();
        //private readonly ReplyContainer replyContainer;

        public PostController(PostContainer postcontainer, ReplyContainer replycontainer)
        {
            this.Container = postcontainer;
            //this.replyContainer = replycontainer;
        }
        public IActionResult Index()
        {
            PostViewModel vm = new PostViewModel();
            List<Post> posts = new List<Post>();
            posts = Container.GetAll();
            //List<PostDetailVM> vms = new List<PostDetailVM>();
            vm.PostViewModels = vmconverter.ModelsToViewModels(posts);
            return View(vm);

        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CreatePost(PostDetailVM vm)
        {
            Post post = vmconverter.ViewModelToModel(vm);
            Container.Insert(post);
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int id)
        {
            PostDetailVM vm = new PostDetailVM();
            Post post = Container.GetById(id);
            vm = vmconverter.ModelToViewModel(post);
            return View(vm);
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
