using System;
using System.Collections.Generic;
using System.Text;
using DatabaseLayer.Interfaces;
using Database_Layer.DTO_s;
using Forum_App.Models.Data;
using Database_Layer.Interfaces;

namespace Business_Layer.DTOConverters
{
    public class PostDTOConverter : IDTOConverter<PostDTO, Post>
    {
        public List<Post> DTOsToModels(List<PostDTO> DTOs)
        {
            List<Post> posts = new List<Post>();
            foreach (PostDTO dto in DTOs)
            {
                Post post = new Post(dto.Id, dto.Title, dto.PostContent, dto.PostTime, dto.AccountId, dto.ForumId);
                posts.Add(post);
            }
            return posts;
        }

        public Post DtoToModel(PostDTO dto)
        {
            Post post = new Post(dto.Id, dto.Title, dto.PostContent, dto.PostTime, dto.AccountId, dto.ForumId);
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
                dto.AccountId = post.AccountId;
                dto.ForumId = post.ForumId;
                DTOs.Add(dto);
            }
            return DTOs;
        }

        public PostDTO ModelToDTO(Post model)
        {
            PostDTO dto = new PostDTO()
            {
                Id = model.Id,
                Title = model.Title,
                PostContent = model.PostContent,
                PostTime = model.PostTime,
                AccountId = model.AccountId,
                ForumId = model.ForumId,
            };
            return dto;
        }
    }
}
