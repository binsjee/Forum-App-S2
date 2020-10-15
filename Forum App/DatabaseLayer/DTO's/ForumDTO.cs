using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseLayer.DTO_s
{
    public class ForumDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte Image { get; set; }
        public DateTime CreationDate { get; set; }

        public IEnumerable<PostDTO> Posts { get; set; }
    }
}
