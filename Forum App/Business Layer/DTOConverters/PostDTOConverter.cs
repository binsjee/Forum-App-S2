using System;
using System.Collections.Generic;
using System.Text;
using DatabaseLayer.Interfaces;
using Database_Layer.DTO_s;
using Forum_App.Models.Data;
using Database_Layer.Interfaces;

namespace Business_Layer.DTOConverters
{
    class PostDTOConverter : IDTOConverter<PostDTO, Post>
    {
        public Post DtoToModel(PostDTO dto)
        {
            Post post = new Post()
            {
                Title = dto.Title,
                PostContent = dto.PostContent
            };
            return post;
        }

        public PostDTO ModelToDTO(Post model)
        {
            PostDTO dto = new PostDTO()
            {
                Title = model.Title,
                PostContent = model.PostContent
            };
            return dto;
        }
    }
}
