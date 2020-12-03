using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Layer.DTO_s
{
    public class ReplyDTO
    {
        public int Id { get; set; }
        public string ReplyContent { get; set; }
        public bool Pinned { get; set; }
        public DateTime ReactionTime { get; set; }
        public int PostId { get; set; }
        public int AccountId { get; set; }
        public ReplyDTO(int id)
        {
            Id = id;
        }
        public ReplyDTO()
        {

        }
    }
}
