using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation_Layer.ViewModels
{
    public class MessageViewModel
    {
        public List<MessageDetailVM> Messages { get; set; } = new List<MessageDetailVM>();
        public AccountDetailVM Sender { get; set; }
        public AccountDetailVM Receiver { get; set; }
    }
}
