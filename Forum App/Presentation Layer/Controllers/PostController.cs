using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Presentation_Layer.Converters;
using Microsoft.AspNetCore.Mvc;
using Forum_App.Models.Data;
using Presentation_Layer.ViewModels;
using Forum_App.Containers;

namespace Presentation_Layer.Controllers
{
    public class PostController : Controller
    {
        private readonly PostVMConverter vmconverter = new PostVMConverter();
        private readonly PostContainer postContainer;

        public PostController(PostContainer container)
        {
            this.postContainer = container;
        }
        public IActionResult Index()
        {

            List<Post> posts = new List<Post>();
            posts = postContainer.GetAll();
            List<PostDetailVM> vms = new List<PostDetailVM>();
            vms = vmconverter.ModelsToViewModels(posts);
            return View();

        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CreatePost(PostDetailVM vm)
        {
            Post post = vmconverter.ViewModelToModel(vm);
            postContainer.Insert(post);
            return RedirectToAction("Index");
        }

    }
}
