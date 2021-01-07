using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Forum_App.Models.Data
{
    public class Reply
    {
        public Reply(int id, string replyContent, bool pinned, DateTime reactionTime, int postId, int accountId, string username)
        {
            Id = id;
            ReplyContent = replyContent;
            Pinned = pinned;
            ReactionTime = reactionTime;
            PostId = postId;
            AccountId = accountId;
            Username = username;
        }

        public int Id { get; private set; }
        public string ReplyContent { get; set; }
        public bool Pinned { get; set; }
        public DateTime ReactionTime { get; set; }
        public int PostId { get; set; }
        public int AccountId { get; set; }
        public string Username { get; set; }
        

    }
}
