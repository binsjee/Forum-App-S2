using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business_Layer;
using Presentation_Layer.ViewModels;
using Forum_App.Models.Data;
using Presentation_Layer.ViewModelConverters;
using Presentation_Layer.Converters;

namespace Presentation_Layer.ViewModelConverters
{
    public class ForumVMConverter : IViewModelConverter<Forum, ForumDetailVM>
    {
        PostVMConverter converter = new PostVMConverter();
        public List<ForumDetailVM> ModelsToViewModels(List<Forum> models)
        {
            List<ForumDetailVM> vms = new List<ForumDetailVM>();
            foreach(Forum forum in models)
            {
                ForumDetailVM vm = new ForumDetailVM();
                vm.Id = forum.Id;
                vm.Title = forum.Title;
                vm.Description = forum.Description;
                vm.CreationDate = forum.CreationDate;
                vm.CreatorID = forum.CreatorID;
                vms.Add(vm);
            }
            return vms;
        }

        public ForumDetailVM ModelToViewModel(Forum model)
        {
            if (model.Posts != null)
            {
                List<PostDetailVM> posts = new List<PostDetailVM>();
                foreach (Post post in model.Posts)
                {
                    posts.Add(converter.ModelToViewModel(post));
                }
                ForumDetailVM vm = new ForumDetailVM()
                {
                    Id = model.Id,
                    Title = model.Title,
                    Description = model.Title,
                    CreationDate = model.CreationDate,
                    CreatorID = model.CreatorID,
                };
                return vm;
            }
            else
            {
                ForumDetailVM vm = new ForumDetailVM()
                {
                    Id = model.Id,
                    Title = model.Title,
                    Description = model.Title,
                    CreationDate = model.CreationDate,
                    CreatorID = model.CreatorID,
                };
                return vm;
            }
        }

        public List<Forum> ViewModelsToModels(List<ForumDetailVM> viewmodels)
        {
            List<Forum> forums = new List<Forum>();
            foreach(ForumDetailVM vm in viewmodels)
            {
                Forum forum = new Forum(vm.Id);
                forum.Title = vm.Title;
                forum.Description = vm.Description;
                forum.CreationDate = vm.CreationDate;
                forum.CreatorID = vm.CreatorID;
                forums.Add(forum);
            }
            return forums;
        }

        public Forum ViewModelToModel(ForumDetailVM viewmodel)
        {
            Forum forum = new Forum(viewmodel.Id)
            {
                Title = viewmodel.Title,
                Description = viewmodel.Description,
                CreationDate = viewmodel.CreationDate,
                CreatorID = viewmodel.CreatorID,
            };
            return forum;
        }
    }
}
