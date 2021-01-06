using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Database_Layer.DTO_s;
using Database_Layer.Interfaces;
using DatabaseLayer.Interfaces;
using DatabaseLayer.Parsers;
using Forum_App.Contexts;
using Microsoft.Extensions.Configuration;

namespace DatabaseLayer.Contexts
{
    public class SQLForumContext : SQLBaseContext, IForumContext
    {
        public SQLForumContext(IConfiguration config) : base(config)
        {

        }
        public List<ForumDTO> GetAll()
        {
            List<ForumDTO> forums = new List<ForumDTO>();
            try
            {
                string sql = "SELECT * FROM Forum";

                DataSet results = ExecuteSql(sql, new List<KeyValuePair<string, string>>());
                for(int x = 0; x < results.Tables[0].Rows.Count; x++)
                {
                    ForumDTO dto = DataSetParser.DataSetToForum(results, x);
                    forums.Add(dto);
                }
                return forums;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public ForumDTO GetById(int id)
        {
            try
            {
                string sql = "SELECT * FROM Forum WHERE ID = @ID";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("ID", id.ToString()),
                };
                DataSet results = ExecuteSql(sql, parameters);
                ForumDTO dto = DataSetParser.DataSetToForum(results, 0);
                return dto;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public long Insert(ForumDTO dto)
        {
            try
            {
                string sql = "INSERT INTO Forum(Title, Description, CreationDate, CreatorID) OUTPUT INSERTED.ID VALUES(@Title, @Description, CURRENT_TIMESTAMP, @CreatorID)";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("Title", dto.Title),
                    new KeyValuePair<string, string>("Description", dto.Description),
                    new KeyValuePair<string, string>("CreatorID", dto.CreatorID.ToString()),
                };
                int results = ExecuteInsert(sql, parameters);
                return results;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
