using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation_Layer.ViewModels
{
    public class ReplyDetailVM
    {
        public int Id { get; set; }
        public string ReplyContent { get; set; }
        public bool Pinned { get; set; }
        public DateTime ReactionTime { get; set; }
        public int PostId { get; set; }
        public int AccountId { get; set; }
        public AccountDetailVM account { get; set; } = new AccountDetailVM();
        public string Username { get; set; }
    }
}
