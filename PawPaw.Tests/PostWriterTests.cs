using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using PawPaw.Core;

namespace PawPaw.Tests
{
    [TestFixture]
    public class PostWriterTests
    {
        private Mock<IPostRepository> _mockPostRepo;
        private Mock<ICommentRepository> _mockCommentRepo;

        [SetUp]
        public void Setup()
        {
            _mockPostRepo = new Mock<IPostRepository>();
            _mockCommentRepo = new Mock<ICommentRepository>();
        }

        [Test]
        public void CreatePost_NoContent_ShouldFail()
        {
            // arrange
            var postWriter = new PostWriter(_mockPostRepo.Object, _mockCommentRepo.Object);

            // act
            Action action = () =>
                postWriter.CreatePost(new Post(), null);
            
            // assert
            action.ShouldThrow<Exception>();
        }
         
    }
}