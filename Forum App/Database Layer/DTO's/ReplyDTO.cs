using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseLayer.DTO_s
{
    public class ReplyDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool Pinned { get; set; }
        public PostDTO Post { get; set; }
    }
}
