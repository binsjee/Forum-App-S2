using System;
using System.Collections.Generic;
using System.Text;
using DatabaseLayer.Interfaces;
using Database_Layer.DTO_s;
using Forum_App.Models.Data;
using Database_Layer.Interfaces;


namespace Business_Layer.DTOConverters
{
    class ReplyDTOConverter : IDTOConverter<ReplyDTO, Reply>
    {
        public List<Reply> DTOsToModels(List<ReplyDTO> DTOs)
        {
            List<Reply> replies = new List<Reply>();
            foreach (ReplyDTO dto in DTOs)
            {
                Reply reply = new Reply();
                reply.Id = dto.Id;
                reply.ReplyContent = dto.ReplyContent;
                reply.Pinned = dto.Pinned;
                reply.ReactionTime = dto.ReactionTime;
                reply.PostId = dto.PostId;
                reply.AccountId = dto.AccountId;
                reply.Username = dto.Username;
                replies.Add(reply);
            }
            return replies;
        }

        public Reply DtoToModel(ReplyDTO dto)
        {
            Reply reply = new Reply()
            {
                Id = dto.Id,
                ReplyContent = dto.ReplyContent,
                Pinned = dto.Pinned,
                ReactionTime = dto.ReactionTime,
                PostId = dto.PostId,
                AccountId = dto.PostId,
                Username = dto.Username,
            };
            return reply;
        }

        public List<ReplyDTO> ModelsToDTOs(List<Reply> models)
        {
            List<ReplyDTO> DTOs = new List<ReplyDTO>();
            foreach (Reply reply in models)
            {
                ReplyDTO dto = new ReplyDTO();
                dto.Id = reply.Id;
                dto.ReplyContent = reply.ReplyContent;
                dto.Pinned = reply.Pinned;
                dto.ReactionTime = reply.ReactionTime;
                dto.PostId = reply.PostId;
                dto.AccountId = reply.AccountId;
                dto.Username = reply.Username;
                DTOs.Add(dto);
            }
            return DTOs;
        }

        public ReplyDTO ModelToDTO(Reply model)
        {
            ReplyDTO dto = new ReplyDTO()
            {
                Id = model.Id,
                ReplyContent = model.ReplyContent,
                Pinned = model.Pinned,
                ReactionTime = model.ReactionTime,
                PostId = model.PostId,
                AccountId = model.PostId,
                Username = model.Username,
            };
            return dto;
        }
    }
}
