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
            stub.tests = new List<ForumDTO>();

            List<Forum> forums = container.GetAll();

            Assert.NotEmpty(forums);
        }
        [Theory]
        [InlineData(1)]
        public void ForumGetByIdTest(int id)
        {
            stub.test = new ForumDTO(id);

            ForumDTO result = converter.ModelToDTO(container.GetById(stub.test.Id));

            stub.test.Should().BeEquivalentTo(result);
        }

        [Fact]
        public void ForumInsertTest()
        {
            stub.test = new ForumDTO();
            Forum forum = converter.DtoToModel(stub.test);
            long result = container.Insert(forum);

            Assert.Equal(0, result);
        }
    }
}
