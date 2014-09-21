using System;
using BlogEngine.Models;
using NUnit.Framework;

namespace BlogEngine.UnitTests
{
    [TestFixture]
    class DisplayDateTests
    {
        // Test each possible display date output
        [Test]
        public void Verify1MinuteAgo()
        {
            DateTime date = DateTime.Now.AddSeconds(-30);

            string output = date.ToDisplayDate();

            Assert.AreEqual("Just now", output);
        }
    }
}
