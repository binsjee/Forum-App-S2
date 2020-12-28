using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database_Layer.Interfaces;
using Business_Layer.DTOConverters;
using DatabaseLayer.Interfaces;
using Database_Layer.DTO_s;
using Forum_App.Models.Data;

namespace Forum_App.Containers
{
    public class AccountContainer
    {
        protected readonly IAccountContext context;
        private readonly AccountDTOConverter converter = new AccountDTOConverter();

        public AccountContainer(IAccountContext context)
        {
            this.context = context;
        }
        public long Insert(Account account)
        {
            AccountDTO dto = new AccountDTO();
            dto = converter.ModelToDTO(account);
            return context.Insert(dto);
        }
        public Account GetByName(Account account)
        {
            AccountDTO dto = new AccountDTO();
            dto = converter.ModelToDTO(account);
            return converter.DtoToModel(context.GetByName(dto));
        }
        public List<Account> GetAll()
        {
            List<AccountDTO> DTOs = new List<AccountDTO>();
            DTOs = context.GetAll();
            List<Account> accounts = new List<Account>();
            accounts = converter.DTOsToModels(DTOs);
            return accounts;
        }
        public Account GetById(int id)
        {
            Account account = new Account();
            AccountDTO dto = new AccountDTO();
            dto = context.GetById(id);
            account = converter.DtoToModel(dto);
            return account;
        }
    }
}
