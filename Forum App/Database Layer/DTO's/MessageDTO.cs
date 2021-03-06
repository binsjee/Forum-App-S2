﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Layer.DTO_s
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageTime { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public List<MessageDTO> Messages { get; set; }
        public MessageDTO()
        {

        }
        public MessageDTO(int id)
        {
            this.Id = id;
        }

        public MessageDTO(int id, string title, string messageContent, DateTime messageTime, int senderId, int receiverId)
        {
            Id = id;
            Title = title;
            MessageContent = messageContent;
            MessageTime = messageTime;
            SenderId = senderId;
            ReceiverId = receiverId;
        }
        public MessageDTO(int id, string title, string messageContent, int senderId, int receiverId)
        {
            Id = id;
            Title = title;
            MessageContent = messageContent;
            SenderId = senderId;
            ReceiverId = receiverId;
        }
    }
}
