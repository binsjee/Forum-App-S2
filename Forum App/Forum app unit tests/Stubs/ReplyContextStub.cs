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
        private List<ReplyDTO> tests = new List<ReplyDTO>()
        {

        }
        ;
        public bool Delete(ReplyDTO dto)
        {
            tests.Add(dto);
            if (tests == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return true;
        }

        public List<ReplyDTO> GetAll()
        {
            ReplyDTO dto = new ReplyDTO(1, "Content", false, 1, 1, "binsjee");
            tests.Add(dto);
            if (tests == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return tests;
        }

        public ReplyDTO GetById(int id)
        {
            tests.Add(new ReplyDTO(1, "Content", false, 1, 1, "binsjee"));
            if (tests == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return tests[0];
        }

        public long Insert(ReplyDTO dto)
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
