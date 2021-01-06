using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Business_Layer.DTOConverters;
using Forum_app_unit_tests.Stubs;
using Forum_App.Containers;
using Database_Layer.DTO_s;
using Forum_App.Models.Data;
using FluentAssertions;

namespace Forum_app_unit_tests.Tests
{
    public class ReplyContainerTest
    {
        private ReplyDTOConverter converter = new ReplyDTOConverter();
        private static ReplyContextStub stub = new ReplyContextStub();
        private ReplyContainer container = new ReplyContainer(stub);

        [Fact]
        public void ReplyGetAllTest()
        {
            stub.tests = new List<ReplyDTO>();

            List<Reply> replies = container.GetAll();

            Assert.NotEmpty(replies);
        }
        [Theory]
        [InlineData(1)]
        public void ReplyGetByIdTest(int id)
        {
            stub.test = new ReplyDTO(id);

            ReplyDTO result = converter.ModelToDTO(container.GetById(stub.test.Id));

            stub.test.Should().BeEquivalentTo(result);
        }
        [Fact]
        public void ReplyInsertTest()
        {
            stub.test = new ReplyDTO();
            Reply reply = converter.DtoToModel(stub.test);
            long result = container.Insert(reply);

            Assert.Equal(0, result);
        }
        [Fact]
        public void ReplyDeleteTest()
        {
            stub.test = new ReplyDTO();
            Reply reply = converter.DtoToModel(stub.test);
            bool result = container.Delete(reply);

            Assert.True(result);
        }
    }
}
