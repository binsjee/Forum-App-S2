using Database_Layer.DTO_s;
using DatabaseLayer.Interfaces;
using Forum_App.Contexts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseLayer.Contexts
{
    public class SQLForumContext : SQLBaseContext, IForumContext
    {
        public SQLForumContext(IConfiguration config) : base(config)
        {

        }
        public List<ForumDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public ForumDTO GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
