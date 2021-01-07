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
    public class ForumContainerTest
    {
        private ForumDTOConverter converter = new ForumDTOConverter();
        private static ForumContextStub stub = new ForumContextStub();
        private ForumContainer container = new ForumContainer(stub);

        [Fact]
        public void ForumGetAllTest()
        {
            List<Forum> forums = container.GetAll();

            Assert.NotEmpty(forums);
        }
        [Theory]
        [InlineData(1, "General", "Description",1)]
        public void ForumGetByIdTest(int id,string title, string description, int creatorid)
        {
            ForumDTO dto = new ForumDTO(id, title, description, creatorid);

            ForumDTO result = converter.ModelToDTO(container.GetById(id));

            dto.Should().BeEquivalentTo(result);
        }

        [Theory]
        [InlineData(1, "Titel", "Description", "2020-12-12", 1)]
        public void ForumInsertTest(int id, string title, string description, string date, int creatorid)
        {
            DateTime DateParsed = DateTime.Parse(date); 

            long result = container.Insert(new Forum(id, title, description, DateParsed,creatorid));

            Forum f = container.GetById(1);

            Assert.Equal(f.Id, result);
        }
    }
}
