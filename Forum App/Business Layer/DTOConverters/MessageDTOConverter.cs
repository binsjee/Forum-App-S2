using System;
using System.Collections.Generic;
using System.Text;
using Database_Layer.DTO_s;
using Forum_App.Models.Data;
using Database_Layer.Interfaces;


namespace Business_Layer.DTOConverters
{
    public class MessageDTOConverter : IDTOConverter<MessageDTO, Message>
    {
        public List<Message> DTOsToModels(List<MessageDTO> DTOs)
        {
            List<Message> messages = new List<Message>();
            foreach(MessageDTO dto in DTOs)
            {
                Message message = new Message();
                message.Id = dto.Id;
                message.Title = dto.Title;
                message.MessageContent = dto.MessageContent;
                message.MessageTime = dto.MessageTime;
                message.SenderId = dto.SenderId;
                message.ReceiverId = dto.ReceiverId;
                messages.Add(message);
            }
            return messages;
        }

        public Message DtoToModel(MessageDTO dto)
        {
            Message message = new Message()
            {
                Id = dto.Id,
                Title = dto.Title,
                MessageContent = dto.MessageContent,
                MessageTime = dto.MessageTime,
                SenderId = dto.SenderId,
                ReceiverId = dto.ReceiverId,
            };
            return message;
        }

        public List<MessageDTO> ModelsToDTOs(List<Message> models)
        {
            List<MessageDTO> DTOs = new List<MessageDTO>();
            foreach (Message message in models)
            {
                MessageDTO dto = new MessageDTO();
                dto.Id = message.Id;
                dto.Title = message.Title;
                dto.MessageContent = message.MessageContent;
                dto.MessageTime = message.MessageTime;
                dto.SenderId = message.SenderId;
                dto.ReceiverId = message.ReceiverId;
                DTOs.Add(dto);
            }
            return DTOs;
        }

        public MessageDTO ModelToDTO(Message model)
        {
            MessageDTO dto = new MessageDTO()
            {
                Id = model.Id,
                Title = model.Title,
                MessageContent = model.MessageContent,
                MessageTime = model.MessageTime,
                SenderId = model.SenderId,
                ReceiverId = model.ReceiverId,
            };
            return dto;
        }
    }
}
