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

        public bool Delete(PostDTO dto)
        {
            try
            {
                string sql = "DELETE FROM Post WHERE ID = @ID";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("ID", dto.Id.ToString())
                };
                ExecuteSql(sql, parameters);
                return true;
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
                string sql = "SELECT ID, Title, PostContent, PostTime, AccountID FROM Post";

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
                string sql = "SELECT ID, Title, PostContent, PostTime, AccountID FROM Post WHERE ID = @ID";
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
                string sql = "INSERT INTO Post(Title, PostContent, PostTime, AccountID) OUTPUT INSERTED.ID VALUES(@Title, @PostContent, CURRENT_TIMESTAMP, @Account_ID)";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("Title", dto.Title),
                    new KeyValuePair<string, string>("PostContent", dto.PostContent),
                    new KeyValuePair<string, string>("Account_ID", dto.AccountId.ToString()),
                };
                int result = ExecuteInsert(sql, parameters);
                return result;

            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public bool PostUpdate(PostDTO dto)
        {
            try
            {
                string sql = "UPDATE Post SET Title = @Title, PostContent = @PostContent WHERE ID = @Id";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Id", dto.Id.ToString()),
                    new KeyValuePair<string, string>("Title", dto.Title),
                    new KeyValuePair<string, string>("PostContent", dto.PostContent),
                };
                ExecuteUpdate(sql, parameters);
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
