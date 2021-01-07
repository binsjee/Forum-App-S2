using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business_Layer.DTOConverters;
using Database_Layer.DTO_s;
using Forum_App.Models.Data;
using DatabaseLayer.Interfaces;

namespace Forum_App.Containers
{
    public class MessageContainer
    {
        protected readonly IMessageContext context;
        private readonly MessageDTOConverter converter = new MessageDTOConverter();
        public MessageContainer(IMessageContext context)
        {
            this.context = context;
        }
        public List<Message> GetAllBySender(int id)
        {
            List<MessageDTO> DTOs = new List<MessageDTO>();
            DTOs = context.GetAllBySender(id);
            List<Message> messages = new List<Message>();
            messages = converter.DTOsToModels(DTOs);
            return messages;

        }
        public List<Message> GetAllByReceiver(int id)
        {
            List<MessageDTO> DTOs = new List<MessageDTO>();
            DTOs = context.GetAllByReceiver(id);
            List<Message> messages = new List<Message>();
            messages = converter.DTOsToModels(DTOs);
            return messages;

        }
        public long Insert(Message message)
        {
            MessageDTO dto = new MessageDTO();
            dto = converter.ModelToDTO(message);
            return context.Insert(dto);
        }
        public Message GetById(int id)
        {
            MessageDTO dto = new MessageDTO();
            dto = context.GetById(id);
            Message message = converter.DtoToModel(dto);
            return message;
        }
    }
}
