﻿using Database_Layer.DTO_s;
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
        public List<ReplyDTO> GetAll()
        {
            //List<ReplyDTO> replies = new List<ReplyDTO>();
            //try
            //{
            //    string sql = "SELECT ID, ReplyContent, Pinned, ReactionTime, PostID, AccountID FROM Reply";
            //    DataSet results = ExecuteSql(sql, new List<KeyValuePair<string, string>>());

            //    for(int x = 0; x < results.Tables[0].Rows.Count; x++)
            //    {
            //        ReplyDTO dto = DataSetParser.DataSetToReply(results, x);

            //    }
            //}
            throw new NotImplementedException();
        }

        public ReplyDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public long Insert(ReplyDTO dto)
        {
            try
            {
                string sql = "INSERT INTO Reply(ReplyContent, Pinned, ReactionTime, PostID, AccountID) OUTPUT INSERTED.ID VALUES(@ReplyContent, @pinned, CURRENT_TIMESTAMP, 0, 0)";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("ReplyContent", dto.ReplyContent),
                    new KeyValuePair<string, string>("Pinned", dto.Pinned.ToString()),
                    //new KeyValuePair<string, string>("PostID", dto.PostId.ToString())

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
