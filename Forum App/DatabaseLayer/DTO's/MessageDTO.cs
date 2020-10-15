using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseLayer.DTO_s
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public AccountDTO Sender { get; set; }
        public AccountDTO Receiver { get; set; }
        public List<MessageDTO> Messages { get; set; }
    }
}
