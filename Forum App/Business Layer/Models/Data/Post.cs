using Business_Layer.DTOConverters;
using Database_Layer.Interfaces;
using DatabaseLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum_App.Models.Data
{
    public class Post
    {
        public Post(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string PostContent { get; set; }
        public DateTime PostTime { get; set; }
        public long postNumber { get; set; }
        public int AccountId { get; set; }
        public int ForumId { get; set; }

        public List<Reply> Replies { get; set; }
        private IPostUpdateContext postContext { get; set;}
        private readonly PostDTOConverter converter = new PostDTOConverter();
        public bool Update(IPostUpdateContext context)
        {
            this.postContext = context;
            context.PostUpdate(converter.ModelToDTO(this));
            return true;
        }
    }
}
