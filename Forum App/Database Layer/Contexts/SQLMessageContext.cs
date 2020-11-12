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
    public class SQLMessageContext : SQLBaseContext, IMessageContext
    {
        public SQLMessageContext(IConfiguration config) : base(config)
        {

        }
        public List<MessageDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public MessageDTO GetById(int id)
        {
            throw new NotImplementedException();
        }
    }

}
