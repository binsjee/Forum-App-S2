using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database_Layer.Interfaces;
using Business_Layer.DTOConverters;
using Database_Layer.DTO_s;
using Forum_App.Models.Data;
using DatabaseLayer.Interfaces;

namespace Forum_App.Containers
{
    public class PostContainer
    {
        protected readonly IPostContext context;
        private readonly PostDTOConverter converter = new PostDTOConverter();

        public PostContainer(IPostContext context)
        {
            this.context = context;
        }

        public long Insert(Post post)
        {
            PostDTO dto = new PostDTO();
            dto = converter.ModelToDTO(post);
            return context.Insert(dto);
        }
        public List<Post> GetAll()
        {
            List<PostDTO> DTOs = new List<PostDTO>();
            DTOs = context.GetAll();
            List<Post> posts = new List<Post>();
            posts = converter.DTOsToModels(DTOs);
            return posts;
        }
    }
}
