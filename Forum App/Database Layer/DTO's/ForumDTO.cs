using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Layer.DTO_s
{
    public class ForumDTO
    {
        public ForumDTO(int id)
        {
            Id = id;
        }
        public ForumDTO()
        {

        }

        public ForumDTO(int id, string title, string description, int creatorID)
        {
            Id = id;
            Title = title;
            Description = description;
            CreatorID = creatorID;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte Image { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatorID { get; set; }
        public List<PostDTO> Posts { get; set; }
    }
}
