using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseLayer.DTO_s
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public long postNumber { get; set; }

        public ForumDTO Forum { get; set; }
        public IEnumerable<ReplyDTO> Replies { get; set; }
    }
}
