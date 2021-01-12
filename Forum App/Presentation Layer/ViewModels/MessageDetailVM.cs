using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation_Layer.ViewModels
{
    public class MessageDetailVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageTime { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public List<AccountDetailVM> accounts { get; set; } = new List<AccountDetailVM>();
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }

    }
}
