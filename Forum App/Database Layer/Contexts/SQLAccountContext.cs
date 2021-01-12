using Database_Layer.DTO_s;
using DatabaseLayer.Interfaces;
using DatabaseLayer.Parsers;
using Forum_App.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Newtonsoft.Json;
//using System.Linq;
//using System.Net.Http;
//using System.Runtime.InteropServices.ComTypes;
//using System.Threading.Tasks;
//using System.Xml;
//using System.Xml.Schema;

using System.Text;

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
                string sql = "SELECT ID, FirstName, LastName, Email, Password, Username, Administrator FROM [Account]";
                DataSet results = ExecuteSql(sql, new List<KeyValuePair<string, string>>());

                for (int x = 0; x < results.Tables[0].Rows.Count; x++)
                {
                    AccountDTO a = DataSetParser.DataSetToAccount(results, x);
                    accountList.Add(a);
                }
                return accountList;
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public AccountDTO GetById(int id)
        {
            try
            {
                string sql = "SELECT ID, FirstName, LastName, Email, Password, Username, Administrator FROM Account WHERE ID = @ID";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("ID", id.ToString())
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

        public long Insert(AccountDTO dto)
        {
            try
            {
                string sql = "INSERT INTO Account(FirstName, LastName, Email, Password, Username, Administrator) OUTPUT INSERTED.ID VALUES(@FirstName, @LastName, @Email, @Password, @Username, 0)";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("FirstName", dto.FirstName),
                    new KeyValuePair<string, string>("LastName", dto.LastName),
                    new KeyValuePair<string, string>("Email", dto.Email),
                    new KeyValuePair<string, string>("Password", dto.Password),
                    new KeyValuePair<string, string>("Username", dto.Username)
                };
                int result = ExecuteInsert(sql, parameters);
                return result;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool Update(AccountDTO a)
        {
            throw new NotImplementedException();
        }
        public bool Login(AccountDTO dto)
        {
            try
            {
                string sql = "SELECT * FROM Account WHERE Username=@Username AND Password=@Password";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Username", dto.Username),
                    new KeyValuePair<string, string>("Password", dto.Password)
                };
                DataSet results = ExecuteSql(sql, parameters);
                AccountDTO Dto = DataSetParser.DataSetToAccount(results, 0);

                
                return true;
                
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public AccountDTO GetByName(AccountDTO dto)
        {
            try
            {
                string sql = "SELECT * FROM Account WHERE Username = @Username AND Password = @Password";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("Username", dto.Username),
                    new KeyValuePair<string, string>("Password", dto.Password),
                };

                DataSet results = ExecuteSql(sql, parameters);
                AccountDTO a = DataSetParser.DataSetToAccount(results, 0);
                return a;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
