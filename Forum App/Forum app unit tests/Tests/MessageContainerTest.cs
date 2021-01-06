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
    public class MessageContainerTest
    {
        private MessageDTOConverter converter = new MessageDTOConverter();
        private static MessageContextStub stub = new MessageContextStub();
        private MessageContainer container = new MessageContainer(stub);
        [Theory]
        [InlineData(1)]
        public void MessageGetAllBySenderTest(int id)
        {
            stub.tests = new List<MessageDTO>();
            List<Message> messages = container.GetAllBySender(id);
            Assert.NotEmpty(messages);
        }

        [Theory]
        [InlineData(1)]
        public void MessageGetAllByReceiverTest(int id)
        {
            stub.tests = new List<MessageDTO>();
            List<Message> messages = container.GetAllByReceiver(id);
            Assert.NotEmpty(messages);
        }
        [Fact]
        public void MessageInsertTest()
        {
            stub.test = new MessageDTO();
            Message message = converter.DtoToModel(stub.test);
            long result = container.Insert(message);

            Assert.Equal(0, result);
        }
    }
}
