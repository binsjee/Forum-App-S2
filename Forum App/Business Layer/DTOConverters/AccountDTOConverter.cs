using System;
using System.Collections.Generic;
using System.Text;
using Database_Layer.Interfaces;
using Database_Layer.DTO_s;
using Forum_App.Models.Data;

namespace Business_Layer.DTOConverters
{
    class AccountDTOConverter : IDTOConverter<AccountDTO, Account>
    {
        public List<Account> DTOsToModels(List<AccountDTO> DTOs)
        {
            throw new NotImplementedException();
        }

        public Account DtoToModel(AccountDTO dto)
        {
            Account account = new Account()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = dto.Password,
                Username = dto.Username
            };
            return account;
        }

        public List<AccountDTO> ModelsToDTOs(List<Account> models)
        {
            throw new NotImplementedException();
        }

        public AccountDTO ModelToDTO(Account model)
        {
            AccountDTO dto = new AccountDTO()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
                Username = model.Username
            };
            return dto;
        }
    }
}
