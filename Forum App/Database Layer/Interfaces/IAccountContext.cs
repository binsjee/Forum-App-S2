﻿using Database_Layer.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseLayer.Interfaces
{
    public interface IAccountContext : IGenericQueries<AccountDTO>
    {
        bool Update(AccountDTO a);
        long Insert(AccountDTO dto);
        AccountDTO GetByName(AccountDTO dto);
    }
}
