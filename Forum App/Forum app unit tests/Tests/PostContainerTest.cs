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
            stub.tests = new List<PostDTO>();

            List<Post> posts = container.GetAll();

            Assert.NotEmpty(posts);
        }
        [Theory]
        [InlineData(1)]
        public void PostGetByIdTest(int id)
        {
            stub.test = new PostDTO(id);

            PostDTO result = converter.ModelToDTO(container.GetById(stub.test.Id));

            stub.test.Should().BeEquivalentTo(result);
        }
        [Fact]
        public void PostInsertTest()
        {
            stub.test = new PostDTO();
            Post post = converter.DtoToModel(stub.test);
            long result = container.Insert(post);

            Assert.Equal(0, result);
        }
        [Fact]
        public void PostDeleteTest()
        {
            stub.test = new PostDTO();
            Post post = converter.DtoToModel(stub.test);
            bool result = container.Delete(post);

            Assert.True(result);
        }
    }
}
