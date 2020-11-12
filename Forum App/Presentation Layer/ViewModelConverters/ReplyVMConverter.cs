using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business_Layer;
using Presentation_Layer.ViewModels;
using Forum_App.Models.Data;
using System.Net.Mime;

namespace Presentation_Layer.ViewModelConverters
{
    public class ReplyVMConverter : IViewModelConverter<Reply, ReplyDetailVM>
    {
        public List<ReplyDetailVM> ModelsToViewModels(List<Reply> models)
        {
            List<ReplyDetailVM> vms = new List<ReplyDetailVM>();
            foreach(Reply reply in models)
            {
                ReplyDetailVM vm = new ReplyDetailVM();
                vm.Id = reply.Id;
                vm.ReplyContent = reply.ReplyContent;
                vm.Pinned = reply.Pinned;
                vm.ReactionTime = reply.ReactionTime;
                vm.PostId = reply.PostId;
                vm.AccountId = reply.AccountId;
                vms.Add(vm);
            }
            return vms;
        }

        public ReplyDetailVM ModelToViewModel(Reply model)
        {
            ReplyDetailVM vm = new ReplyDetailVM()
            {
                Id = model.Id,
                ReplyContent = model.ReplyContent,
                Pinned = model.Pinned,
                ReactionTime = model.ReactionTime,
                PostId = model.PostId,
                AccountId = model.AccountId,
            };
            return vm;
        }

        public List<Reply> ViewModelsToModels(List<ReplyDetailVM> viewmodels)
        {
            List<Reply> replies = new List<Reply>();
            foreach(ReplyDetailVM vm in viewmodels)
            {
                Reply reply = new Reply();
                reply.Id = vm.Id;
                reply.ReplyContent = vm.ReplyContent;
                reply.Pinned = vm.Pinned;
                reply.ReactionTime = vm.ReactionTime;
                reply.PostId = vm.PostId;
                reply.AccountId = vm.AccountId;
                replies.Add(reply);
            }
            return replies;
        }

        public Reply ViewModelToModel(ReplyDetailVM viewmodel)
        {
            Reply reply = new Reply()
            {
                Id = viewmodel.Id,
                ReplyContent = viewmodel.ReplyContent,
                Pinned = viewmodel.Pinned,
                ReactionTime = viewmodel.ReactionTime,
                PostId = viewmodel.PostId,
                AccountId = viewmodel.AccountId,
            };
            return reply;
        }
    }
}
