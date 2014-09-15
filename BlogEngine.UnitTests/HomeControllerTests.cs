using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BlogEngine.Controllers;
using BlogEngine.Models.Repositories;
using BlogEngine.UnitTests.Models;
using NUnit.Framework;

namespace BlogEngine.UnitTests
{
    [TestFixture]
    class HomeControllerTests
    {
        [Test]
        public void IndexGetAsksForIndexView()
        {
            // Arrange
            var controller = GetHomeController(new InMemoryPostRepository());

            // Act
            //ActionResult result = controller.Index();
            ViewResult result = (ViewResult) controller.Index();

            // Assert
            Assert.AreEqual("Index", result.ViewName);
        }

        private HomeController GetHomeController(IPostRepository repository)
        {
            HomeController controller = new HomeController(repository);

            controller.ControllerContext = new ControllerContext
            {
                Controller = controller,
                RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
            };

            return controller;
        }

        private class MockHttpContext : HttpContextBase
        {
            private readonly IPrincipal _user = new GenericPrincipal(new GenericIdentity("admin"), null);

            public override IPrincipal User
            {
                get { return _user; }
                set { base.User = value; }
            }
        }
    }

    
}
