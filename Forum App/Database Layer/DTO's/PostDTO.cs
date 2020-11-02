using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Layer.DTO_s
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PostContent { get; set; }
        public string PostTime { get; set; }
        public long postNumber { get; set; }
        public int AccountId { get; set; }

        public ForumDTO Forum { get; set; }
        public IEnumerable<ReplyDTO> Replies { get; set; }
        public PostDTO(int id)
        {
            id = Id;
        }
        public PostDTO()
        {

        }
    }
}
