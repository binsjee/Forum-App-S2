using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database_Layer.DTO_s;
using Database_Layer.Interfaces;
using DatabaseLayer.Interfaces;
using Forum_App.Contexts;
using Microsoft.Extensions.Configuration;

namespace DatabaseLayer.Contexts
{
    public class SQLPostContext : SQLBaseContext, IPostContext
    {
        public SQLPostContext(IConfiguration config) : base(config)
        {

        }
        public List<PostDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public PostDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public long Insert(PostDTO dto)
        {
            try
            {
                string sql = "INSERT INTO Post(Title, PostContent, PostTime) OUTPUT INSERTED.ID VALUES(@Title, @PostContent @PostTime)";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("Title", dto.Title),
                    new KeyValuePair<string, string>("PostContent", dto.PostContent),
                    new KeyValuePair<string, string>("PostTime", DateTime.Now.ToString())
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
