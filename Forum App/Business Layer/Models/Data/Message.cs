using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum_App.Models.Data
{
    public class Message
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Account Sender { get; set; }
        public Account Receiver { get; set; }
        public List<Message> Messages { get; set; }
    }
}
