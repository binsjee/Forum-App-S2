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
        public DateTime PostTime { get; set; }
        public int AccountId { get; set; }
        public int ForumId { get; set; }

        public List<ReplyDTO> Replies { get; set; }
        public PostDTO(int id)
        {
            Id = id;
        }
        public PostDTO()
        {

        }
    }
}
