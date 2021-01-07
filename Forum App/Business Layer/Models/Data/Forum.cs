using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum_App.Models.Data
{
    public class Forum
    {
        public Forum(int id, string title, string description, DateTime creationdate, int creatorID)
        {
            Id = id;
            Title = title;
            Description = description;
            CreationDate = creationdate;
            CreatorID = creatorID;
        }

        public int Id { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte Image { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatorID { get; set; }

        public List<Post> Posts { get; set; }

    }
}
