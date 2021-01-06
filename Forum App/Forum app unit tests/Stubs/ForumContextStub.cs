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
        public ForumDTO test;
        public List<ForumDTO> tests;

        public List<ForumDTO> GetAll()
        {
            if(tests == null)
            {
                throw new NullReferenceException("No value returned");
            }
            tests.Add(new ForumDTO(1));
            return tests;
        }
        public ForumDTO GetById(int id)
        {
            if (test == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return test;
        }

        public long Insert(ForumDTO dto)
        {
            if (test == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return 0;
        }
    }
}
