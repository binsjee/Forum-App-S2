using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;
using Database_Layer.DTO_s;

namespace DatabaseLayer.Parsers
{
    public class DataSetParser
    {
        public static AccountDTO DataSetToAccount(DataSet set, int rowIndex)
        {
            if (set.Tables[0].Rows.Count > 0)
            {
                return new AccountDTO((int)set.Tables[0].Rows[rowIndex][0])
                {
                    FirstName = (string)set.Tables[0].Rows[rowIndex][1],
                    LastName = (string)set.Tables[0].Rows[rowIndex][2],
                    Email = (string)set.Tables[0].Rows[rowIndex][3],
                    Password = (string)set.Tables[0].Rows[rowIndex][4],
                    Username = (string)set.Tables[0].Rows[rowIndex][5],
                    Administrator = (bool)set.Tables[0].Rows[rowIndex][6]
                };
            }
            else
            {
                return new AccountDTO();
            }
        }
        public static PostDTO DataSetToPost(DataSet set, int rowIndex)
        {
            if (set.Tables[0].Rows.Count > 0)
            {

                return new PostDTO((int)set.Tables[0].Rows[rowIndex][0])
                {
                    Title = (string)set.Tables[0].Rows[rowIndex][1],
                    PostContent = (string)set.Tables[0].Rows[rowIndex][2],
                    PostTime = (DateTime)set.Tables[0].Rows[rowIndex][3],
                    AccountId = (int)set.Tables[0].Rows[rowIndex][4],
                    ForumId = (int)set.Tables[0].Rows[rowIndex][5],
                };
            }
            else
            {
                return new PostDTO();
            }
        }
        public static ReplyDTO DataSetToReply(DataSet set, int rowIndex)
        {
            if(set.Tables[0].Rows.Count > 0)
            {
                return new ReplyDTO((int)set.Tables[0].Rows[rowIndex][0])
                {
                    ReplyContent = (string)set.Tables[0].Rows[rowIndex][1],
                    Pinned = (bool)set.Tables[0].Rows[rowIndex][2],
                    ReactionTime = (DateTime)set.Tables[0].Rows[rowIndex][3],
                    PostId = (int)set.Tables[0].Rows[rowIndex][4],
                    AccountId = (int)set.Tables[0].Rows[rowIndex][5],
                    Username = (string)set.Tables[0].Rows[rowIndex][6],
                };
            }
            else
            {
                return new ReplyDTO();
            }
        }
        public static MessageDTO DataSetToMessage(DataSet set, int rowIndex)
        {
            if(set.Tables[0].Rows.Count > 0)
            {
                return new MessageDTO((int)set.Tables[0].Rows[rowIndex][0])
                {
                    Title = (string)set.Tables[0].Rows[rowIndex][1],
                    MessageContent = (string)set.Tables[0].Rows[rowIndex][2],
                    MessageTime = (DateTime)set.Tables[0].Rows[rowIndex][3],
                    SenderId = (int)set.Tables[0].Rows[rowIndex][4],
                    ReceiverId = (int)set.Tables[0].Rows[rowIndex][5],
                };
            }
            else
            {
                return new MessageDTO();
            }
        }
        public static MessageDTO DataSetToSentMessages(DataSet set, int rowIndex)
        {
            if (set.Tables[0].Rows.Count > 0)
            {
                return new MessageDTO((int)set.Tables[0].Rows[rowIndex][0])
                {
                    Title = (string)set.Tables[0].Rows[rowIndex][1],
                    MessageContent = (string)set.Tables[0].Rows[rowIndex][2],
                    MessageTime = (DateTime)set.Tables[0].Rows[rowIndex][3],
                    ReceiverId = (int)set.Tables[0].Rows[rowIndex][5],
                };
            }
            else
            {
                return new MessageDTO();
            }
        }
        public static MessageDTO DataSetToReceivedMessages(DataSet set, int rowIndex)
        {
            if (set.Tables[0].Rows.Count > 0)
            {
                return new MessageDTO((int)set.Tables[0].Rows[rowIndex][0])
                {
                    Title = (string)set.Tables[0].Rows[rowIndex][1],
                    MessageContent = (string)set.Tables[0].Rows[rowIndex][2],
                    MessageTime = (DateTime)set.Tables[0].Rows[rowIndex][3],
                    SenderId = (int)set.Tables[0].Rows[rowIndex][4],
                };
            }
            else
            {
                return new MessageDTO();
            }
        }
        public static ForumDTO DataSetToForum(DataSet set, int rowIndex)
        {
            if(set.Tables[0].Rows.Count > 0)
            {
                return new ForumDTO((int)set.Tables[0].Rows[rowIndex][0])
                {
                    Title = (string)set.Tables[0].Rows[rowIndex][1],
                    Description = (string)set.Tables[0].Rows[rowIndex][2],
                    CreationDate = (DateTime)set.Tables[0].Rows[rowIndex][4],
                    CreatorID = (int)set.Tables[0].Rows[rowIndex][5],
                };
            }
            else
            {
                return new ForumDTO();
            }
        }
    }
}
