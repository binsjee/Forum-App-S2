using System;
using System.Collections.Generic;
using System.Text;
using DatabaseLayer.Interfaces;
using Database_Layer.DTO_s;
using DatabaseLayer.Parsers;

namespace Forum_app_unit_tests.Stubs
{
    class MessageContextStub : IMessageContext
    {
        private List<MessageDTO> tests = new List<MessageDTO>()
        {

        }
        ;
        public List<MessageDTO> GetAll()
        {
            MessageDTO dto = new MessageDTO(1, "title", "content", 1, 1);
            tests.Add(dto);
            if(tests == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return tests;
        }

        public List<MessageDTO> GetAllByReceiver(int id)
        {
            string date = "2020-12-12";
            DateTime DateParsed = DateTime.Parse(date);
            MessageDTO dto = new MessageDTO(1, "title", "content",DateParsed, 1, 1);
            tests.Add(dto);
            if (tests == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return tests;
        }

        public List<MessageDTO> GetAllBySender(int id)
        {
            string date = "2020-12-12";
            DateTime DateParsed = DateTime.Parse(date);
            MessageDTO dto = new MessageDTO(1, "title", "content",DateParsed, 1, 1);
            tests.Add(dto);
            if (tests == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return tests;
        }

        public MessageDTO GetById(int id)
        {
            tests.Add(new MessageDTO(1, "title", "content", 1, 2));
            if(tests == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return tests[0];
        }

        public long Insert(MessageDTO dto)
        {
            if (tests == null)
            {
                throw new NullReferenceException("No value returned");
            }
            tests.Add(dto);
            return tests[0].Id;
        }
    }
}
