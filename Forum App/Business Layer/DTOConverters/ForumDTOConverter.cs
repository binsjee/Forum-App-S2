using System;
using System.Collections.Generic;
using System.Text;
using Database_Layer.DTO_s;
using Forum_App.Models.Data;
using Database_Layer.Interfaces;

namespace Business_Layer.DTOConverters
{
    public class ForumDTOConverter : IDTOConverter<ForumDTO, Forum>
    {
        public List<Forum> DTOsToModels(List<ForumDTO> DTOs)
        {
            List<Forum> forums = new List<Forum>();
            foreach(ForumDTO dto in DTOs)
            {
                Forum forum = new Forum(dto.Id);
                forum.Title = dto.Title;
                forum.Description = dto.Description;
                forum.Image = dto.Image;
                forum.CreationDate = dto.CreationDate;
                forum.CreatorID = dto.CreatorID;
                forums.Add(forum);
            }
            return forums;
        }

        public Forum DtoToModel(ForumDTO dto)
        {
            Forum forum = new Forum(dto.Id)
            {
                Title = dto.Title,
                Description = dto.Description,
                Image = dto.Image,
                CreationDate = dto.CreationDate,
                CreatorID = dto.CreatorID,
            };
            return forum;
        }

        public List<ForumDTO> ModelsToDTOs(List<Forum> models)
        {
            List<ForumDTO> DTOs = new List<ForumDTO>();
            foreach (Forum forum in models)
            {
                ForumDTO dto = new ForumDTO(forum.Id);
                dto.Title = forum.Title;
                dto.Description = forum.Description;
                dto.Image = forum.Image;
                dto.CreationDate = forum.CreationDate;
                dto.CreatorID = forum.CreatorID;
                DTOs.Add(dto);
            }
            return DTOs;
        }

        public ForumDTO ModelToDTO(Forum model)
        {
            ForumDTO dto = new ForumDTO(model.Id)
            {
                Title = model.Title,
                Description = model.Description,
                Image = model.Image,
                CreationDate = model.CreationDate,
                CreatorID = model.CreatorID,
            };
            return dto;
        }
    }
}
