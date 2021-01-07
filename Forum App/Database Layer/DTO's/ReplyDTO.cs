using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Layer.DTO_s
{
    public class ReplyDTO
    {
        public int Id { get; set; }
        public string ReplyContent { get; set; }
        public bool Pinned { get; set; }
        public DateTime ReactionTime { get; set; }
        public int PostId { get; set; }
        public int AccountId { get; set; }
        public string Username { get; set; }
        public ReplyDTO(int id)
        {
            Id = id;
        }
        public ReplyDTO()
        {

        }

        public ReplyDTO(int id, string replyContent, bool pinned, DateTime reactionTime, int postId, int accountId, string username)
        {
            Id = id;
            ReplyContent = replyContent;
            Pinned = pinned;
            ReactionTime = reactionTime;
            PostId = postId;
            AccountId = accountId;
            Username = username;
        }
        public ReplyDTO(int id, string replyContent, bool pinned, int postId, int accountId, string username)
        {
            Id = id;
            ReplyContent = replyContent;
            Pinned = pinned;
            PostId = postId;
            AccountId = accountId;
            Username = username;
        }
    }
}
