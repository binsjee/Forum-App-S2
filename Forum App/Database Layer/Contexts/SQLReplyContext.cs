using Database_Layer.DTO_s;
using DatabaseLayer.Interfaces;
using DatabaseLayer.Parsers;
using Forum_App.Contexts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DatabaseLayer.Contexts
{
    public class SQLReplyContext : SQLBaseContext, IReplyContext
    {
        public SQLReplyContext(IConfiguration config) : base(config)
        {

        }

        public void Delete(ReplyDTO dto)
        {
            try
            {
                string sql = "DELETE FROM Reply WHERE ID = @ID";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("ID", dto.Id.ToString())
                };
                ExecuteSql(sql, parameters);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public List<ReplyDTO> GetAll()
        {
            List<ReplyDTO> replies = new List<ReplyDTO>();
            try
            {
                string sql = "SELECT ID, ReplyContent, Pinned, ReactionTime, PostID, AccountID FROM Reply";
                DataSet results = ExecuteSql(sql, new List<KeyValuePair<string, string>>());

                for (int x = 0; x < results.Tables[0].Rows.Count; x++)
                {
                    ReplyDTO dto = DataSetParser.DataSetToReply(results, x);
                    replies.Add(dto);
                }
                return replies;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public ReplyDTO GetById(int id)
        {
            try
            {
                string sql = "SELECT ID, ReplyContent, Pinned, ReactionTime, PostID, AccountID FROM Reply WHERE ID = @ID";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("ID", id.ToString()),
                };
                DataSet results = ExecuteSql(sql, parameters);
                ReplyDTO dto = DataSetParser.DataSetToReply(results, 0);
                return dto;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public long Insert(ReplyDTO dto)
        {
            try
            {
                string sql = "INSERT INTO Reply(ReplyContent, Pinned, ReactionTime, PostID, AccountID) OUTPUT INSERTED.ID VALUES(@ReplyContent, @pinned, CURRENT_TIMESTAMP, @PostId, @AccountID)";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("ReplyContent", dto.ReplyContent),
                    new KeyValuePair<string, string>("Pinned", dto.Pinned.ToString()),
                    new KeyValuePair<string, string>("PostID", dto.PostId.ToString()),
                    new KeyValuePair<string, string>("AccountID", dto.AccountId.ToString()),

                };
                int result = ExecuteInsert(sql, parameters);
                return result;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
