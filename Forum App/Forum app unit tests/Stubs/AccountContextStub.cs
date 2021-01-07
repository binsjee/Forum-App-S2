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
        private List<AccountDTO> Tests = new List<AccountDTO>()
        {

        }
        ;
        public List<AccountDTO> GetAll()
        {
            AccountDTO dto = new AccountDTO(1, "Vince", "Heesters", "vincietjeu@hotmail.nl", "nee", "binsjee", true);
            Tests.Add(dto);
            if(Tests == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return Tests;
        }

        public AccountDTO GetById(int id)
        {
            Tests.Add(new AccountDTO(1, "Vince", "Heesters", "vincietjeu@hotmail.nl", "nee", "binsjee", true));
            if(Tests == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return Tests[0];
        }

        public AccountDTO GetByName(AccountDTO dto)
        {
            Tests.Add(new AccountDTO(1, "Vince", "Heesters", "vincietjeu@hotmail.nl", "nee", "binsjee", true));
            if (Tests == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return Tests[0];
        }

        public long Insert(AccountDTO dto)
        {
            if(Tests == null)
            {
                throw new NullReferenceException("No value returned");
            }
            Tests.Add(dto);
            return Tests[0].Id;
        }

        public bool Update(AccountDTO a)
        {
            Tests.Add(a);
            if(Tests == null)
            {
                throw new NullReferenceException("No value returned");
            }
            return true;
        }
    }
}
