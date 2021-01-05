using System;
using System.Collections.Generic;
using System.Text;
using DatabaseLayer.Interfaces;
using Database_Layer.DTO_s;
using DatabaseLayer.Parsers;

namespace Forum_app_unit_tests.Stubs
{
    class AccountContextStub : IAccountContext
    {
        public AccountDTO TestDTO;
        public List<AccountDTO> TestDTOs;
        public List<AccountDTO> GetAll()
        {
            if(TestDTOs == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return TestDTOs;
        }

        public AccountDTO GetById(int id)
        {
            if(TestDTO == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return TestDTO;
        }

        public AccountDTO GetByName(AccountDTO dto)
        {
            if(TestDTO == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return TestDTO;
        }

        public long Insert(AccountDTO dto)
        {
            if(TestDTO == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return 0;
        }

        public bool Update(AccountDTO a)
        {
            if(TestDTO == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return true;
        }
    }
}
