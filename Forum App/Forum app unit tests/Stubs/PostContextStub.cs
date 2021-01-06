using System;
using System.Collections.Generic;
using System.Text;
using DatabaseLayer.Interfaces;
using Database_Layer.DTO_s;
using DatabaseLayer.Parsers;


namespace Forum_app_unit_tests.Stubs
{
    class PostContextStub : IPostContext
    {
        public PostDTO test;
        public List<PostDTO> tests;

        public bool Delete(PostDTO dto)
        {
            if (test == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return true; ;
        }

        public List<PostDTO> GetAll()
        {
            if (tests == null)
            {
                throw new NullReferenceException("No value returned");
            }
            tests.Add(new PostDTO(1));
            return tests;
        }

        public PostDTO GetById(int id)
        {
            if (test == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return test;
        }

        public long Insert(PostDTO dto)
        {
            if (test == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return 0;
        }

        public bool PostUpdate(PostDTO dto)
        {
            if (test == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return true;
        }
    }
}
