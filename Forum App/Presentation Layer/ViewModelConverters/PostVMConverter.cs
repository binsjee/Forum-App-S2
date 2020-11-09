using System;
using System.Collections.Generic;
using System.Text;
using Business_Layer;
using Presentation_Layer.ViewModels;
using Forum_App.Models.Data;

namespace Presentation_Layer.Converters
{
    public class PostVMConverter : IViewModelConverter<Post, PostDetailVM>
    {
        public List<PostDetailVM> ModelsToViewModels(List<Post> models)
        {
            List<PostDetailVM> vms = new List<PostDetailVM>();
            foreach(Post post in models)
            {
                PostDetailVM vm = new PostDetailVM();
                vm.Id = post.Id;
                vm.Title = post.Title;
                vm.PostContent = post.PostContent;
                vm.PostTime = post.PostTime;
                vms.Add(vm);
            }
            return vms;
        }

        public PostDetailVM ModelToViewModel(Post model)
        {
            PostDetailVM vm = new PostDetailVM()
            {
                Id = model.Id,
                Title = model.Title,
                PostContent = model.PostContent,
                PostTime = model.PostTime,
            };
            return vm;
        }

        public List<Post> ViewModelsToModels(List<PostDetailVM> viewmodels)
        {
            List<Post> posts = new List<Post>();
            foreach(PostDetailVM vm in viewmodels)
            {
                Post post = new Post();
                post.Title = vm.Title;
                post.PostContent = vm.PostContent;
                posts.Add(post);
            }
            return posts;
        }

        public Post ViewModelToModel(PostDetailVM viewmodel)
        {
            Post post = new Post()
            {
                Title = viewmodel.Title,
                PostContent = viewmodel.PostContent
            };
            return post;
        }
    }
}
