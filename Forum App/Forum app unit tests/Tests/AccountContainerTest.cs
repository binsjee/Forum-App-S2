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
        private AccountDTOConverter converter = new AccountDTOConverter();
        private static AccountContextStub Stub = new AccountContextStub();
        private AccountContainer container = new AccountContainer(Stub);
        [Theory]
        [InlineData(1, "Vince", "Heesters", "vincietjeu@hotmail.nl", "nee", "binsjee", true)]
        public void AccountGetByIdTest(int id, string firstname, string lastname, string email, string password, string username, bool admin)
        {
            AccountDTO dto = new AccountDTO(id, firstname, lastname, email, password, username, admin);

            AccountDTO result = converter.ModelToDTO(container.GetById(id));

            dto.Should().BeEquivalentTo(result);
        }
        [Fact]
        public void AccountGetAllTest()
        {
            List<Account> accounts = container.GetAll();

            Assert.NotEmpty(accounts);
        }
        [Theory]
        [InlineData(1, "Vince", "Heesters", "vincietjeu@hotmail.nl", "nee", "binsjee", true)]
        public void AccountGetByNameTest(int id, string firstname, string lastname, string email, string password, string username, bool admin)
        {
            AccountDTO dto = new AccountDTO(id, firstname, lastname, email, password, username, admin);

            AccountDTO result = converter.ModelToDTO(container.GetByName(converter.DtoToModel(dto)));

            dto.Should().BeEquivalentTo(result);
        }
        [Theory]
        [InlineData(1, "Vince", "Heesters", "vincietjeu@hotmail.nl", "nee", "binsjee", true)]
        public void AccountInsertTest(int id, string firstname, string lastname, string email, string password, string username, bool admin)
        {
            long result = container.Insert(new Account(id, firstname, lastname, email, password, username, admin));

            Account account = container.GetById(1);

            Assert.Equal(account.Id, result);
        }
    }
}
