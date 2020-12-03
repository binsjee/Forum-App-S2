using Database_Layer.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseLayer.Interfaces
{
    public interface IReplyContext : IGenericQueries<ReplyDTO>
    {
        public long Insert(ReplyDTO dto);
        void Delete(ReplyDTO dto);
    }
}
