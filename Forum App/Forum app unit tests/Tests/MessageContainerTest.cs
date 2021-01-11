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
        [InlineData(1, "title", "content","2020-12-12", 1, 1)]
        public void MessageGetAllBySenderTest(int id, string title, string description,string date, int senderid, int receiverid)
        {
            DateTime DateParsed = DateTime.Parse(date);
            List<Message> messages = new List<Message>() { new Message(id, title, description, DateParsed, senderid, receiverid) };

            List<Message> results = container.GetAllBySender(senderid);

            messages.Should().BeEquivalentTo(results);
        }

        [Theory]
        [InlineData(1, "title", "content", "2020-12-12", 1, 1)]
        public void MessageGetAllByReceiverTest(int id, string title, string description,string date, int senderid, int receiverid)
        {
            DateTime DateParsed = DateTime.Parse(date);
            List<Message> messages = new List<Message>() { new Message(id, title, description, DateParsed, senderid, receiverid) };

            List<Message> results = container.GetAllByReceiver(receiverid);

            messages.Should().BeEquivalentTo(results);
        }
        [Theory]
        [InlineData(1, "title", "content", "2020-12-12", 1, 1)]
        public void MessageInsertTest(int id, string title, string description, string date, int senderid, int receiverid)
        {
            DateTime DateParsed = DateTime.Parse(date);
            long result = container.Insert(new Message(id, title, description, DateParsed, senderid, receiverid));

            Message m = container.GetById(1);

            Assert.Equal(m.Id, result);
        }
        [Theory]
        [InlineData(1, "title", "content", "2020-12-12", 1, 1)]
        public void MessageGetById(int id, string title, string description, string date, int senderid, int receiverid)
        {
            DateTime DateParsed = DateTime.Parse(date);
            MessageDTO dto = new MessageDTO(id, title, description, DateParsed, senderid, receiverid);

            MessageDTO result = converter.ModelToDTO(container.GetById(id));

            dto.Should().BeEquivalentTo(result);
        }
    }
}
