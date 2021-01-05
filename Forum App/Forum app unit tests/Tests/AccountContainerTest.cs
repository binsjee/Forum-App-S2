using System;
using Xunit;
using Business_Layer.DTOConverters;
using Forum_app_unit_tests.Stubs;
using Forum_App.Containers;
using Database_Layer.DTO_s;
using Forum_App.Models.Data;
using FluentAssertions;
using System.Collections.Generic;

namespace Forum_app_unit_tests
{
    public class AccountContainerTest
    {
        private AccountDTOConverter accountConverter = new AccountDTOConverter();
        private static AccountContextStub accountContextStub = new AccountContextStub();
        private AccountContainer accountContainer = new AccountContainer(accountContextStub);
        [Theory]
        [InlineData(1)]
        public void AccountGetByIdTest(int id)
        {
            accountContextStub.TestDTO = new AccountDTO(id);
            AccountDTO account = accountConverter.ModelToDTO(accountContainer.GetById(accountContextStub.TestDTO.Id));

            accountContextStub.TestDTO.Should().BeEquivalentTo(account);
        }
        [Fact]
        public void AccountGetAllTest()
        {
            accountContextStub.TestDTOs = new List<AccountDTO>();
            foreach(Account a in accountContainer.GetAll())
            {
                accountContextStub.TestDTOs.Add(accountConverter.ModelToDTO(a));
            }

            Assert.Empty(accountContextStub.TestDTOs);
        }
        [Theory]
        [InlineData(1)]
        public void AccountGetByNameTest(int id)
        {
            accountContextStub.TestDTO = new AccountDTO(id);
            AccountDTO account = accountConverter.ModelToDTO(accountContainer.GetByName(accountConverter.DtoToModel(accountContextStub.TestDTO)));

            accountContextStub.TestDTO.Should().BeEquivalentTo(account);
        }
        [Theory]
        [InlineData(1, "Vince", "Heesters", "vincietjeu@hotmail.nl", "Test", "binsjee", false)]
        public void AccountInsertTest(int id, string firstname, string lastname, string email, string password, string username, bool admin)
        {
            accountContextStub.TestDTO = new AccountDTO(id, firstname, lastname, email, password, username, admin);

            long result = accountContainer.Insert(accountConverter.DtoToModel(accountContextStub.TestDTO));

            Assert.Equal(0, result);
        }
    }
}
