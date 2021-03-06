﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation_Layer.ViewModels
{
    public class PostDetailVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PostContent { get; set; }
        public DateTime PostTime { get; set; }
        public int AccountId { get; set; }
        public int ForumId { get; set; }
        public List<ReplyDetailVM> Replies { get; set; } = new List<ReplyDetailVM>();
        public AccountDetailVM account { get; set; } = new AccountDetailVM();
    }
}
