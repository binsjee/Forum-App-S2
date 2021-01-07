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
    public class PostContainerTest
    {
        private PostDTOConverter converter = new PostDTOConverter();
        private static PostContextStub stub = new PostContextStub();
        private PostContainer container = new PostContainer(stub);

        [Fact]
        public void PostGetAllTest()
        {

            List<Post> posts = container.GetAll();

            Assert.NotEmpty(posts);
        }
        [Theory]
        [InlineData(1, "Titel", "Description", 1, 1)]
        public void PostGetByIdTest(int id, string title, string description,int accountid, int forumid)
        {
            PostDTO dto = new PostDTO(id, title, description, accountid, forumid);

            PostDTO result = converter.ModelToDTO(container.GetById(id));

            dto.Should().BeEquivalentTo(result);
        }
        [Theory]
        [InlineData(1,"Titel","Description","2020-12-12",1,1)]
        public void PostInsertTest(int id, string title, string description, string creationtime, int accountid, int forumid)
        {
            DateTime DateParsed = DateTime.Parse(creationtime);
            long result = container.Insert(new Post(id, title, description, DateParsed, accountid, forumid));

            Post p = container.GetById(1);

            Assert.Equal(p.Id, result);
        }
        [Theory]
        [InlineData(1, "Titel", "Description", "2020-12-12", 1, 1)]
        public void PostDeleteTest(int id, string title, string description, string creationtime, int accountid, int forumid)
        {
            DateTime DateParsed = DateTime.Parse(creationtime);
            bool result = container.Delete(new Post(id, title, description, DateParsed, accountid, forumid));

            Assert.True(result);
        }
    }
}
