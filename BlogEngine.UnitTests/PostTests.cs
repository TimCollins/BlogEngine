using System.Collections.Generic;
using BlogEngine.Models.Entities;
using BlogEngine.Models.Repositories;
using NUnit.Framework;

namespace BlogEngine.UnitTests
{
    class PostTests
    {
        [Test]
        public void VerifyCanPopulatePost()
        {
            RepositoryFactory.PostRepository = new TestPostRepository();

            List<Post> posts = RepositoryFactory.PostRepository.GetPosts(1);
            Post post = posts[0];

            Assert.IsNotNull(post);

            Assert.AreEqual(1, post.ID);
            Assert.AreEqual(1, post.CategoryID);
            Assert.AreEqual("This is test post 1. This is the body text.", post.Body);
            Assert.AreEqual(1, post.CreatedBy);
            Assert.AreEqual(1, post.ModifiedBy);
            Assert.AreEqual("Test post 1", post.Subject);
        }

        [Test]
        public void WhenZeroPostsRequestedZeroPostsReturned()
        {
            RepositoryFactory.PostRepository = new TestPostRepository();

            List<Post> posts = RepositoryFactory.PostRepository.GetPosts(0);

            Assert.AreEqual(0, posts.Count);
        }

        [Test]
        public void WhenFivePostsRequestedFivePostsReturned()
        {
            RepositoryFactory.PostRepository = new TestPostRepository();

            List<Post> posts = RepositoryFactory.PostRepository.GetPosts(5);

            Assert.AreEqual(5, posts.Count);
        }
    }
}
