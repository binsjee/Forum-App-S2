using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation_Layer.ViewModels
{
    public class PostReplyViewModel
    {
        public PostDetailVM postVM { get; set; }
        public ReplyDetailVM replyVM { get; set; }
        public List<ReplyDetailVM> replies { get; set; }
    }
}
