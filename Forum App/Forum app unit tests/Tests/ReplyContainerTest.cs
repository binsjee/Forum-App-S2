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

            List<Reply> replies = container.GetAll();

            Assert.NotEmpty(replies);
        }
        [Theory]
        [InlineData(1, "Content", false, 1, 1, "binsjee")]
        public void ReplyGetByIdTest(int id, string content, bool pinned, int postid, int accountid, string username)
        {
            ReplyDTO dto = new ReplyDTO(id, content, pinned, postid, accountid, username);

            ReplyDTO result = converter.ModelToDTO(container.GetById(id));

            dto.Should().BeEquivalentTo(result);
        }
        [Theory]
        [InlineData(1, "Content", false,"2020-12-12", 1, 1, "binsjee")]
        public void ReplyInsertTest(int id, string content, bool pinned, string date, int postid, int accountid, string username)
        {
            DateTime DateParsed = DateTime.Parse(date);
            long result = container.Insert(new Reply(id, content, pinned, DateParsed, postid, accountid, username));

            Reply r = container.GetById(1);

            Assert.Equal(r.Id, result);
        }
        [Theory]
        [InlineData(1, "Content", false, "2020-12-12", 1, 1, "binsjee")]
        public void ReplyDeleteTest(int id, string content, bool pinned, string date, int postid, int accountid, string username)
        {
            DateTime DateParsed = DateTime.Parse(date);
            bool result = container.Delete(new Reply(id, content, pinned, DateParsed, postid, accountid, username));

            Assert.True(result);
        }
    }
}
