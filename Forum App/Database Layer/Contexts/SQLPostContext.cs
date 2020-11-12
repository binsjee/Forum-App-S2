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
    public class SQLPostContext : SQLBaseContext, IPostContext
    {
        public SQLPostContext(IConfiguration config) : base(config)
        {

        }

        public void Delete(PostDTO dto)
        {
            try
            {
                string sql = "DELETE FROM Post WHERE ID = @ID";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("ID", dto.Id.ToString())
                };
                ExecuteSql(sql, parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<PostDTO> GetAll()
        {
            List<PostDTO> posts = new List<PostDTO>();
            try
            {
                string sql = "SELECT ID, Title, PostContent, PostTime FROM Post";

                DataSet results = ExecuteSql(sql, new List<KeyValuePair<string, string>>());

                for(int x = 0; x < results.Tables[0].Rows.Count; x++)
                {
                    PostDTO dto = DataSetParser.DataSetToPost(results, x);
                    posts.Add(dto);
                }
                return posts;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public PostDTO GetById(int id)
        {
            try
            {
                string sql = "SELECT ID, Title, PostContent, PostTime FROM Post WHERE ID = @ID";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("ID", id.ToString()),
                };
                DataSet results = ExecuteSql(sql, parameters);
                PostDTO dto = DataSetParser.DataSetToPost(results, 0);
                return dto;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public long Insert(PostDTO dto)
        {
            try
            {
                string sql = "INSERT INTO Post(Title, PostContent, PostTime) OUTPUT INSERTED.ID VALUES(@Title, @PostContent, CURRENT_TIMESTAMP)";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("Title", dto.Title),
                    new KeyValuePair<string, string>("PostContent", dto.PostContent),
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
