using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum_App.Models.Data
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostTime { get; set; }
        public long postNumber { get; set; }
        public int AccountId { get; set; }

        public Forum Forum { get; set; }
        public IEnumerable<Reply> Replies { get; set; }
    }
}
