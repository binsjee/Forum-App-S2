using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business_Layer.DTOConverters;
using Database_Layer.DTO_s;
using Forum_App.Models.Data;
using DatabaseLayer.Interfaces;

namespace Forum_App.Containers
{
    public class ForumContainer
    {
        protected readonly IForumContext context;
        private readonly ForumDTOConverter converter = new ForumDTOConverter();

        public ForumContainer(IForumContext context)
        {
            this.context = context;
        }
        public long Insert(Forum forum)
        {
            ForumDTO dto = new ForumDTO();
            dto = converter.ModelToDTO(forum);
            return context.Insert(dto);
        }
        public List<Forum> GetAll()
        {
            List<ForumDTO> DTOs = new List<ForumDTO>();
            DTOs = context.GetAll();
            List<Forum> forums = new List<Forum>();
            forums = converter.DTOsToModels(DTOs);
            return forums;
        }
        public Forum GetById(int id)
        {
            Forum forum = new Forum(id);
            ForumDTO dto = new ForumDTO();
            dto = context.GetById(id);
            forum = converter.DtoToModel(dto);
            return forum;
        }
    }
}
