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
        //public PostDTO test;
        private List<PostDTO> tests = new List<PostDTO>()
        {
            //new PostDTO(1, "Titel", "Description", 1, 1)
        }
        ;

        public bool Delete(PostDTO dto)
        {
            tests.Add(dto);
            if (tests == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return true;
        }

        public List<PostDTO> GetAll()
        {
            PostDTO dto = new PostDTO(1, "Titel", "Description", 1, 1);
            tests.Add(dto);
            if (tests == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return tests;
        }

        public PostDTO GetById(int id)
        {
            tests.Add(new PostDTO(1, "Titel", "Description", 1, 1));
            if (tests == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return tests[0];
        }

        public long Insert(PostDTO dto)
        {
            if(tests == null)
            {
                throw new NullReferenceException("No value returned");
            }
            tests.Add(dto);
            return tests[0].Id;
        }

        public bool PostUpdate(PostDTO dto)
        {
            tests.Add(dto);
            if (tests == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return true;
        }
    }
}
