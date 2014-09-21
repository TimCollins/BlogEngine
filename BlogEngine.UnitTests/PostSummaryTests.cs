using System.Collections.Generic;
using BlogEngine.Models.Repositories;
using BlogEngine.Models.ViewModels;
using NUnit.Framework;

namespace BlogEngine.UnitTests
{
    [TestFixture]
    class PostSummaryTests
    {
        [Test]
        public void VerifyCanPopulateSummary()
        {
            RepositoryFactory.PostRepository = new TestPostRepository();

            PostSummary summary = RepositoryFactory.PostRepository.GetPostSummaries(1)[0];

            Assert.IsNotNull(summary);
            Assert.AreEqual("Uncategoried", summary.CategoryName);
            Assert.AreEqual("2014-09-14 13:38:30", summary.DateDetails);
            Assert.AreEqual(1, summary.PostID);
            Assert.AreEqual("Test summary 1", summary.Subject);
            Assert.AreEqual("This is test post 1.", summary.Summary);
            Assert.AreEqual(1, summary.UserID);
            Assert.AreEqual("Admin", summary.UserName);
        }

        [Test]
        public void WhenZeroPostSummariesRequestedZeroPostSummariesReturned()
        {
            RepositoryFactory.PostRepository = new TestPostRepository();

            List<PostSummary> summaries = RepositoryFactory.PostRepository.GetPostSummaries(0);

            Assert.AreEqual(0, summaries.Count);
        }

        [Test]
        public void WhenFivePostSummariesRequestedFivePostSummariesReturned()
        {
            RepositoryFactory.PostRepository = new TestPostRepository();

            List<PostSummary> summaries = RepositoryFactory.PostRepository.GetPostSummaries(5);

            Assert.AreEqual(5, summaries.Count);
        }
    }
}
