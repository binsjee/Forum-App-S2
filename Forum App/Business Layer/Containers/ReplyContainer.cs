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
    public class ReplyContainer
    {
        protected readonly IReplyContext context;
        private readonly ReplyDTOConverter converter = new ReplyDTOConverter();
        public ReplyContainer(IReplyContext context)
        {
            this.context = context;
        }
        public long Insert(Reply reply)
        {
            ReplyDTO dto = new ReplyDTO();
            dto = converter.ModelToDTO(reply);
            return context.Insert(dto);
        }
        public List<Reply> GetAll()
        {
            List<ReplyDTO> DTOs = new List<ReplyDTO>();
            DTOs = context.GetAll();
            List<Reply> replies = new List<Reply>();
            replies = converter.DTOsToModels(DTOs);
            return replies;
        }
        public void Delete(Reply reply)
        {
            ReplyDTO dto = new ReplyDTO();
            dto = converter.ModelToDTO(reply);
            context.Delete(dto);
        }
    }
}
