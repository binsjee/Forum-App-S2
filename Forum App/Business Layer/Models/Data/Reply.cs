using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Forum_App.Models.Data
{
    public class Reply
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool Pinned { get; set; }
        public Post Post { get; set; }
        

    }
}
