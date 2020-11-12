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
    public class SQLReplyContext : SQLBaseContext, IReplyContext
    {
        public SQLReplyContext(IConfiguration config) : base(config)
        {

        }
        public List<ReplyDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public ReplyDTO GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
