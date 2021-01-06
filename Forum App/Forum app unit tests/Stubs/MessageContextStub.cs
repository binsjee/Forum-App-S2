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
        public MessageDTO test;
        public List<MessageDTO> tests;
        public List<MessageDTO> GetAll()
        {
            if(tests == null)
            {
                throw new NullReferenceException("No value returned");
            }
            tests.Add(new MessageDTO(1));
            return tests;
        }

        public List<MessageDTO> GetAllByReceiver(int id)
        {
            if(tests == null)
            {
                throw new NullReferenceException("No value returned");
            }
            tests.Add(new MessageDTO(1));
            return tests;
        }

        public List<MessageDTO> GetAllBySender(int id)
        {
            if (tests == null)
            {
                throw new NullReferenceException("No value returned");
            }
            tests.Add(new MessageDTO(1));
            return tests;
        }

        public MessageDTO GetById(int id)
        {
            if(test == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return test;
        }

        public long Insert(MessageDTO dto)
        {
            if (test == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return 0;
        }
    }
}
