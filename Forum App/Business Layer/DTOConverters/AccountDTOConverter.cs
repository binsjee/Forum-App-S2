using System;
using System.Collections.Generic;
using System.Text;
using Database_Layer.Interfaces;
using Database_Layer.DTO_s;
using Forum_App.Models.Data;

namespace Business_Layer.DTOConverters
{
    public class AccountDTOConverter : IDTOConverter<AccountDTO, Account>
    {
        public List<Account> DTOsToModels(List<AccountDTO> DTOs)
        {
            List<Account> accounts = new List<Account>();
            foreach(AccountDTO dto in DTOs)
            {
                Account account = new Account(dto.Id, dto.FirstName, dto.LastName, dto.Email,dto.Password,dto.Username,dto.Administrator);
                accounts.Add(account);
            }
            return accounts;
        }

        public Account DtoToModel(AccountDTO dto)
        {
            Account account = new Account(dto.Id, dto.FirstName, dto.LastName, dto.Email, dto.Password, dto.Username, dto.Administrator);
            return account;
        }

        public List<AccountDTO> ModelsToDTOs(List<Account> models)
        {
            List<AccountDTO> DTOs = new List<AccountDTO>();
            foreach (Account account in models)
            {
                AccountDTO dto = new AccountDTO();
                dto.Id = account.Id;
                dto.FirstName = account.FirstName;
                dto.LastName = account.LastName;
                dto.Email = account.Email;
                dto.Password = account.Password;
                dto.Username = account.Username;
                dto.Administrator = account.Administrator;
                DTOs.Add(dto);
            }
            return DTOs;
        }

        public AccountDTO ModelToDTO(Account model)
        {
            AccountDTO dto = new AccountDTO()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
                Username = model.Username,
                Administrator = model.Administrator,
            };
            return dto;
        }
    }
}
