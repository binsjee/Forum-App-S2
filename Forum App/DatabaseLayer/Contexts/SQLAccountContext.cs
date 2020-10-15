using DatabaseLayer.DTO_s;
using DatabaseLayer.Interfaces;
using DatabaseLayer.Parsers;
using Forum_App.Contexts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseLayer.Contexts
{
    public class SQLAccountContext : SQLBaseContext, IAccountContext
    {
        public SQLAccountContext(IConfiguration configuration) : base(configuration)
        {

        }

        public List<AccountDTO> GetAll()
        {
            List<AccountDTO> accountList = new List<AccountDTO>();
            try
            {
                string sql = "SELECT AccountID, FirstName, LastName, Email, Password, Username, Administrator FROM [Account]";
                DataSet results = ExecuteSql(sql, new List<KeyValuePair<string, string>>());

                for (int x = 0; x < results.Tables[0].Rows.Count; x++)
                {
                    AccountDTO a = DataSetParser.DataSetToAccount(results, x);
                    accountList.Add(a);
                }
                return accountList;
            }
            catch
            {
                throw;
            }
        }

        public AccountDTO GetById(int id)
        {
            try
            {
                string sql = "SELECT AccountID, FirstName, LastName, Email, Password, Username, Administrator FROM Account WHERE AccountID = @AccountID";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("AccountID", id.ToString())
                };

                DataSet results = ExecuteSql(sql, parameters);
                AccountDTO a = DataSetParser.DataSetToAccount(results, 0);
                return a;
            }
            catch
            {
                return null;
            }
        }

        public long Insert(object T)
        {
            throw new NotImplementedException();
        }

        public bool Update(AccountDTO a)
        {
            throw new NotImplementedException();
        }
    }
}
