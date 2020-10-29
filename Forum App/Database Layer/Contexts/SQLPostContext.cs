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

        public long Insert(object T)
        {
            //try
            //{
            //    string sql = "INSERT INTO Post()"
            //}
            throw new NotImplementedException();
        }

        public long Insert(PostDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
