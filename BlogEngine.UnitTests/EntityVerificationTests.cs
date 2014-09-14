using System;
using BlogEngine.Models.Entities;
using NUnit.Framework;

namespace BlogEngine.UnitTests
{
    /// <summary>
    /// This class verifies the various properties that are part of each entity in the system. 
    /// Things like the User entity having a Name property are tested. If the property doesn't 
    /// exist then the code won't compile so it's more of a verification than any sort of a 
    /// logic check.
    /// </summary>
    [TestFixture]
    class EntityVerificationTests
    {
        [Test]
        public void VerifyUserProperties()
        {
            User user = new User
            {
                ID = 1,
                Name = "Homer Simpson",
                Password = "password",
                CreatedBy = 1,
                CreatedOn = DateTime.Now,
                ModifiedBy = 1,
                ModifiedOn = DateTime.Now
            };

            Assert.IsNotNull(user);
        }

        [Test]
        public void VerifyCategoryProperties()
        {
            Category category = new Category
            {
                ID = 1,
                Name = "Uncategorised",
                CreatedBy = 1,
                CreatedOn = DateTime.Now,
                ModifiedBy = 1,
                ModifiedOn = DateTime.Now
            };

            Assert.IsNotNull(category);
        }

        [Test]
        public void VerifyPostProperties()
        {
            Post post = new Post
            {
                ID = 1,
                CategoryID = 1,
                Subject = "Subject",
                Body = "Body",
                CreatedBy = 1,
                CreatedOn = DateTime.Now,
                ModifiedBy = 1,
                ModifiedOn = DateTime.Now
            };

            Assert.IsNotNull(post);
        }

        [Test]
        public void VerifyCommentProperties()
        {
            Comment comment = new Comment
            {
                ID = 1,
                PostID = 1,
                Title = "Title",
                Body = "Comment",
                CreatedBy = 1,
                CreatedOn = DateTime.Now,
                ModifiedBy = 1,
                ModifiedOn = DateTime.Now
            };

            Assert.IsNotNull(comment);
        }
    }
}
