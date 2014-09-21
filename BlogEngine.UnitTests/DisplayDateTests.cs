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

        [Test]
        public void Verify2MinutesAgo()
        {
            DateTime date = DateTime.Now.AddSeconds(-96);

            string output = date.ToDisplayDate();

            Assert.AreEqual("2 mins ago", output);
        }

        [Test]
        public void Verify7MinutesAgo()
        {
            DateTime date = DateTime.Now.AddSeconds(-400);

            string output = date.ToDisplayDate();

            Assert.AreEqual("7 mins ago", output);
        }

        [Test]
        public void Verify23MinsAgo()
        {
            DateTime date = DateTime.Now.AddSeconds(-1379);

            string output = date.ToDisplayDate();

            Assert.AreEqual("23 mins ago", output);
        }

        [Test]
        public void Verify49MinsAgo()
        {
            DateTime date = DateTime.Now.AddSeconds(-2876);

            string output = date.ToDisplayDate();

            Assert.AreEqual("48 mins ago", output);

        }

        [Test]
        public void Verify59MinsAgo()
        {
            DateTime date = DateTime.Now.AddSeconds(-3535);

            string output = date.ToDisplayDate();

            Assert.AreEqual("59 mins ago", output);
        }

        [Test]
        public void Verify1HourAgo()
        {
            DateTime date = DateTime.Now.AddMinutes(-60);

            string output = date.ToDisplayDate();

            Assert.AreEqual("1 hour ago", output);
        }

        [Test]
        public void Verify1HourAgoAlt()
        {
            DateTime date = DateTime.Now.AddMinutes(-119);

            string output = date.ToDisplayDate();

            Assert.AreEqual("1 hour ago", output);
        }

        [Test]
        public void Verify2HoursAgo()
        {
            DateTime date = DateTime.Now.AddMinutes(-130);

            string output = date.ToDisplayDate();

            Assert.AreEqual("2 hours ago", output);
        }

        [Test]
        public void Verify2HoursAgoAlt()
        {
            DateTime date = DateTime.Now.AddMinutes(-179);

            string output = date.ToDisplayDate();

            Assert.AreEqual("2 hours ago", output);
        }

        [Test]
        public void Verify3HoursAgo()
        {
            DateTime date = DateTime.Now.AddMinutes(-190);

            string output = date.ToDisplayDate();

            Assert.AreEqual("3 hours ago", output);
        }

        [Test]
        public void Verify19HoursAgo()
        {
            DateTime date = DateTime.Now.AddMinutes(-1150);

            string output = date.ToDisplayDate();

            Assert.AreEqual("19 hours ago", output);
        }

        [Test]
        public void Verify23HoursAgo()
        {
            DateTime date = DateTime.Now.AddMinutes(-1410);

            string output = date.ToDisplayDate();

            Assert.AreEqual("23 hours ago", output);
        }

        [Test]
        public void VerifyYesterdayLowerBoundary()
        {
            DateTime date = DateTime.Now.AddMinutes(-2500);

            string output = date.ToDisplayDate();

            Assert.AreEqual("Yesterday", output);
        }

        [Test]
        public void VerifyYesterday()
        {
            DateTime date = DateTime.Now.AddMinutes(-2750);

            string output = date.ToDisplayDate();

            Assert.AreEqual("Yesterday", output);
        }

        [Test]
        public void VerifyYesterdayUpperBoundary()
        {
            DateTime date = DateTime.Now.AddMinutes(-2879);

            string output = date.ToDisplayDate();

            Assert.AreEqual("Yesterday", output);
        }

        [Test]
        public void Verify2DaysAgoLowerBoundary()
        {
            DateTime date = DateTime.Now.AddMinutes(-2881);

            string output = date.ToDisplayDate();

            Assert.AreEqual("2 days ago", output);
        }
        
        [Test]
        public void Verify2DaysAgo()
        {
            DateTime date = DateTime.Now.AddMinutes(-4210);

            string output = date.ToDisplayDate();

            Assert.AreEqual("2 days ago", output);
        }

        [Test]
        public void Verify2DaysAgoUpperBoundary()
        {
            DateTime date = DateTime.Now.AddMinutes(-4319);

            string output = date.ToDisplayDate();

            Assert.AreEqual("2 days ago", output);
        }

        [Test]
        public void VerifyShortDateFormat()
        {
            DateTime date = DateTime.Now.AddMinutes(-5000);

            string output = date.ToDisplayDate();

            Assert.AreEqual("Sep 18 2014", output);
        }
    }
}
