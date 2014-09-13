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
                CreatedBy = 1,
                CreatedOn = DateTime.Now,
                ModifiedBy = 1,
                ModifiedOn = DateTime.Now
            };

            Assert.IsNotNull(user);
        }
    }
}
