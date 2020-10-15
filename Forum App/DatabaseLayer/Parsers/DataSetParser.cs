using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;
using DatabaseLayer.DTO_s;

namespace DatabaseLayer.Parsers
{
    public class DataSetParser
    {
        public static AccountDTO DataSetToAccount(DataSet set, int rowIndex)
        {
            return new AccountDTO((int)set.Tables[0].Rows[rowIndex][0])
            {
                FirstName = (string)set.Tables[0].Rows[rowIndex][1],
                LastName = (string)set.Tables[0].Rows[rowIndex][2],
                Email = (string)set.Tables[0].Rows[rowIndex][3],
                Password = (string)set.Tables[0].Rows[rowIndex][4],
                Username = (string)set.Tables[0].Rows[rowIndex][5],
                Administrator = (bool)set.Tables[0].Rows[rowIndex][6]
            };
        }
    }
}
