using System;
using System.Collections.Generic;
using BlogEngine.Models.Entities;
using BlogEngine.Models.Repositories;
using BlogEngine.UnitTests.Models;
using Moq;
using NUnit.Framework;

namespace BlogEngine.UnitTests
{
    [TestFixture]
    class PostRepositoryTests
    {
        /// <summary>
        /// Basic verification test to ensure things are wired up correctly.
        /// </summary>
        [Test]
        public void CanCreateMockRepository()
        {
            Mock<IPostRepository> postRepository = new Mock<IPostRepository>();
            postRepository.Setup(r => r.GetPosts(It.IsAny<int>())).Returns(new List<Post>());

            Assert.IsNotNull(postRepository);
        }

        // Validate that a zero count returns an empty list.
        [Test]
        public void GetPostsZeroThrowsException()
        {
            PostRepository postRepository = new PostRepository();

            var posts = postRepository.GetPosts(0);

            Assert.IsTrue(posts.Count == 0);
        }

        // Validate that a negative count returns an empty list.
        [Test]
        public void GetPostsNegativeThrowsException()
        {
            PostRepository postRepository = new PostRepository();

            var posts = postRepository.GetPosts(-2);

            Assert.IsTrue(posts.Count == 0);
        }

        // Validate that requesting one post returns one post.
        [Test]
        public void GetOnePostReturnsOnePost()
        {
            InMemoryPostRepository postRepository = new InMemoryPostRepository();

            var posts = postRepository.GetPosts(1);

            Assert.IsTrue(posts.Count == 1);
        }


        // Validate that requesting 5 posts returns 5 even when there are more.
    }
}
