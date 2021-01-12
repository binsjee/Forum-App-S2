using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business_Layer;
using Presentation_Layer.ViewModels;
using Forum_App.Models.Data;
using Presentation_Layer.ViewModelConverters;

namespace Presentation_Layer.ViewModelConverters
{
    public class MessageVMConverter : IViewModelConverter<Message, MessageDetailVM>
    {
        public List<MessageDetailVM> ModelsToViewModels(List<Message> models)
        {
            List<MessageDetailVM> vms = new List<MessageDetailVM>();
            foreach(Message message in models)
            {
                MessageDetailVM vm = new MessageDetailVM();
                vm.Id = message.Id;
                vm.Title = message.Title;
                vm.MessageContent = message.MessageContent;
                vm.MessageTime = message.MessageTime;
                vm.ReceiverId = message.ReceiverId;
                vm.SenderId = message.SenderId;
                vm.SenderName = message.SenderName;
                vm.ReceiverName = message.ReceiverName;
                vms.Add(vm);
            }
            return vms;
        }

        public MessageDetailVM ModelToViewModel(Message model)
        {
            MessageDetailVM vm = new MessageDetailVM()
            {
                Id = model.Id,
                Title = model.Title,
                MessageContent = model.MessageContent,
                MessageTime = model.MessageTime,
                ReceiverId = model.ReceiverId,
                SenderId = model.SenderId,
                SenderName = model.SenderName,
                ReceiverName = model.ReceiverName,
            };
            return vm;
        }

        public List<Message> ViewModelsToModels(List<MessageDetailVM> viewmodels)
        {
            List<Message> messages = new List<Message>();
            foreach (MessageDetailVM vm in viewmodels)
            {
                Message message = new Message(vm.Id, vm.Title, vm.MessageContent,vm.MessageTime,vm.SenderId,vm.ReceiverId,vm.ReceiverName,vm.SenderName);
                messages.Add(message);
            }
            return messages;
        }

        public Message ViewModelToModel(MessageDetailVM viewmodel)
        {
            Message message = new Message(viewmodel.Id,viewmodel.Title,viewmodel.MessageContent,viewmodel.MessageTime,viewmodel.SenderId,viewmodel.ReceiverId,viewmodel.ReceiverName, viewmodel.SenderName);
            return message;
        }
    }
}
