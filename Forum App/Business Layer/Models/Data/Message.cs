﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum_App.Models.Data
{
    public class Message
    {
        public Message(int id, string title, string messageContent, DateTime messageTime, int senderId, int receiverId)
        {
            Id = id;
            Title = title;
            MessageContent = messageContent;
            MessageTime = messageTime;
            SenderId = senderId;
            ReceiverId = receiverId;
        }

        public Message(int id, string title, string messageContent, DateTime messageTime, int senderId, int receiverId, string receivername, string sendername)
        {
            Id = id;
            Title = title;
            MessageContent = messageContent;
            MessageTime = messageTime;
            SenderId = senderId;
            ReceiverId = receiverId;
            ReceiverName = receivername;
            SenderName = sendername;
        }

        public int Id { get; private set; }
        public string Title { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageTime { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string ReceiverName { get; set; }
        public string SenderName { get; set; }
        public List<Message> Messages { get; set; }
    }
}
