using System;
using System.Collections.Generic;
using System.Text;
using DatabaseLayer.Interfaces;
using Database_Layer.DTO_s;
using DatabaseLayer.Parsers;

namespace Forum_app_unit_tests.Stubs
{
    class ReplyContextStub : IReplyContext
    {
        public ReplyDTO test;
        public List<ReplyDTO> tests;
        public bool Delete(ReplyDTO dto)
        {
            if (test == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return true;
        }

        public List<ReplyDTO> GetAll()
        {
            if (tests == null)
            {
                throw new NullReferenceException("No value returned");
            }
            tests.Add(new ReplyDTO(1));
            return tests;
        }

        public ReplyDTO GetById(int id)
        {
            if (test == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return test;
        }

        public long Insert(ReplyDTO dto)
        {
            if (test == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return 0;
        }
    }
}
