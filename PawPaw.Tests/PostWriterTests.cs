using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using PawPaw.Core;
using PawPaw.Writers;

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
            var postWriter = new PostWriter(_mockPostRepo.Object, _mockCommentRepo.Object, null);

            // act
            Action action = () =>
                postWriter.CreatePost(null);
            
            // assert
            action.ShouldThrow<Exception>();
        }
         
    }
}