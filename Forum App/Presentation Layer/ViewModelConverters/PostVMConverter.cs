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
            throw new NotImplementedException();
        }

        public PostDetailVM ModelToViewModel(Post model)
        {
            PostDetailVM vm = new PostDetailVM()
            {
                Title = model.Title,
                PostContent = model.PostContent
            };
            return vm;
        }

        public List<Post> ViewModelsToModels(List<PostDetailVM> viewmodels)
        {
            throw new NotImplementedException();
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
