﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum_App.Models.Data
{
    public class Message
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageTime { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public List<Message> Messages { get; set; }
    }
}
