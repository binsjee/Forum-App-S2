using Database_Layer.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseLayer.Interfaces
{
    public interface IMessageContext : IGenericQueries<MessageDTO>
    {
        List<MessageDTO> GetAllBySender(int id);
        List<MessageDTO> GetAllByReceiver(int id);
        long Insert(MessageDTO dto);
    }
}
