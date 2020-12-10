using Database_Layer.DTO_s;
using DatabaseLayer.Interfaces;
using DatabaseLayer.Parsers;
using Forum_App.Contexts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
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

        public List<MessageDTO> GetAllByReceiver(int id)
        {
            List<MessageDTO> messages = new List<MessageDTO>();
            try
            {
                string sql = "SELECT Title, MessageContent, MessageTime, SenderId FROM Message WHERE ReceiverId = @ReceiverId ";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("ReceiverId", id.ToString()),
                };
                DataSet Results = ExecuteSql(sql, parameters);
                for (int x = 0; x < Results.Tables[0].Rows.Count; x++)
                {
                    MessageDTO dto = DataSetParser.DataSetToMessage(Results, x);
                    messages.Add(dto);
                }
                return messages;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public List<MessageDTO> GetAllBySender(int id)
        {
            List<MessageDTO> messages = new List<MessageDTO>();
            try
            {
                string sql = "SELECT Title, MessageContent, MessageTime, ReceiverId FROM Message WHERE SenderId = @SenderId ";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("SenderId", id.ToString()),
                };
                DataSet Results = ExecuteSql(sql, parameters);
                for(int x = 0; x < Results.Tables[0].Rows.Count; x++)
                {
                    MessageDTO dto = DataSetParser.DataSetToMessage(Results, x);
                    messages.Add(dto);
                }
                return messages;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public MessageDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public long Insert(MessageDTO dto)
        {
            try
            {
                string sql = "INSERT INTO Message(Title, MessageContent, MessageTime, SenderId, ReceiverId) OUTPUT INSERTED.ID VALUES(@Title, @MessageContent, CURRENT_TIMESTAMP, @SenderId, @ReceiverId)";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("Title", dto.Title),
                    new KeyValuePair<string, string>("MessageContent", dto.MessageContent),
                    new KeyValuePair<string, string>("SenderId", dto.SenderId.ToString()),
                    new KeyValuePair<string, string>("ReceiverId", dto.ReceiverId.ToString()),
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
