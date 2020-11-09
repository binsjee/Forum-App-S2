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
        public List<Post> DTOsToModels(List<PostDTO> DTOs)
        {
            List<Post> posts = new List<Post>();
            foreach (PostDTO dto in DTOs)
            {
                Post post = new Post();
                post.Id = dto.Id;
                post.Title = dto.Title;
                post.PostContent = dto.PostContent;
                post.PostTime = dto.PostTime;
                posts.Add(post);
            }
            return posts;
        }

        public Post DtoToModel(PostDTO dto)
        {
            Post post = new Post()
            {
                Title = dto.Title,
                PostContent = dto.PostContent
            };
            return post;
        }

        public List<PostDTO> ModelsToDTOs(List<Post> models)
        {
            List<PostDTO> DTOs = new List<PostDTO>();
            foreach(Post post in models)
            {
                PostDTO dto = new PostDTO();
                dto.Title = post.Title;
                dto.PostContent = post.PostContent;
                DTOs.Add(dto);
            }
            return DTOs;
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
