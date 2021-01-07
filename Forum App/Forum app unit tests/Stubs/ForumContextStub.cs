using System;
using System.Collections.Generic;
using System.Text;
using DatabaseLayer.Interfaces;
using Database_Layer.DTO_s;
using DatabaseLayer.Parsers;

namespace Forum_app_unit_tests.Stubs
{
    class ForumContextStub : IForumContext
    {
        private List<ForumDTO> tests = new List<ForumDTO>()
        {

        }
        ;
        public List<ForumDTO> GetAll()
        {
            ForumDTO dto = new ForumDTO(1, "General", "Description", 1);
            tests.Add(dto);
            if(tests == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return tests;
        }
        public ForumDTO GetById(int id)
        {
            tests.Add(new ForumDTO(1, "General", "Description", 1));
            if (tests == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return tests[0];
        }

        public long Insert(ForumDTO dto)
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
