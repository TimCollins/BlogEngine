using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BlogEngine.Controllers;
using BlogEngine.Models.Entities;
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
            InMemoryPostRepository repo = new InMemoryPostRepository();
            repo.AddPosts(GetTestPosts());
            var controller = GetHomeController(repo);

            // Act
            // Not sure why the horrible-looking cast is required.
            ViewResult result = (ViewResult) controller.Index();

            // Assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void IndexGetRetrievesAllData()
        {
            var repo = new InMemoryPostRepository();
            repo.AddPost(new Post
            {
                Body =
                    "Vestibulum sagittis, sapien in porta condimentum, lectus urna gravida odio, et hendrerit mauris orci sit amet augue. Interdum et malesuada fames ac ante ipsum primis in faucibus. Nam tempus ultricies erat at rhoncus. Proin faucibus justo sed mauris fringilla imperdiet. Sed sapien ipsum, bibendum non tempor vel, mollis eget eros. Aenean nunc erat, maximus quis gravida a, sodales sed sapien. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec pretium nec ligula ac rutrum. Nulla in auctor massa. Suspendisse sagittis nulla at est ornare, vitae feugiat diam convallis. Proin tincidunt odio sit amet tortor sollicitudin pulvinar. Sed iaculis facilisis enim nec ultricies. Nam condimentum vehicula elit. Integer et varius quam, vitae fringilla leo.",
                CategoryID = 1,
                CreatedBy = 1,
                CreatedOn = DateTime.Now.AddHours(-2),
                ID = 7,
                ModifiedBy = 1,
                ModifiedOn = DateTime.Now.AddHours(-2),
                Subject =
                    "Vestibulum sagittis, sapien in porta condimentum, lectus urna gravida odio, et hendrerit mauris orci sit amet augue."
            });
            repo.AddPost(new Post
            {
                Body =
                    "Vivamus tincidunt nunc urna, vitae sodales sapien tincidunt eu. Donec lacus risus, placerat aliquam posuere eget, hendrerit eu justo. Sed erat nunc, laoreet auctor aliquam eu, maximus aliquam mauris. Cras tincidunt rutrum nulla, ac aliquam nibh suscipit ac. Integer mollis orci at ex venenatis pellentesque. Integer ultricies lacus id lectus sodales dignissim. Morbi libero eros, imperdiet in erat vel, fermentum blandit dui. Phasellus fermentum laoreet tincidunt. Aliquam ac risus diam. Fusce commodo nisi non elit tempus mollis at sit amet justo. Donec pretium ligula nec malesuada mollis. Vivamus laoreet quam ut interdum laoreet",
                CategoryID = 1,
                CreatedBy = 1,
                CreatedOn = DateTime.Now.AddHours(-5),
                ID = 8,
                ModifiedBy = 1,
                ModifiedOn = DateTime.Now.AddHours(-5),
                Subject = "Vivamus tincidunt nunc urna, vitae sodales sapien tincidunt eu."
            });

            var posts = repo.GetPosts(5);
            var controller = GetHomeController(repo);

            ViewResult result = (ViewResult)controller.Index();

            var model = (IEnumerable<Post>)result.ViewData.Model;

            Assert.AreEqual(model.ToList().Count, posts.Count);
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

        private static List<Post> GetTestPosts()
        {
            return new List<Post>
            {
                new Post
                {
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer a congue odio. Cras ut elementum nunc. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Morbi metus mi, finibus sollicitudin convallis ut, volutpat nec orci. Mauris tempor justo id est consectetur iaculis. Quisque malesuada elementum massa nec aliquam. Donec id tortor pharetra, iaculis elit ac, mollis ipsum. In id urna odio. Nullam tristique mattis mauris, eu sagittis enim efficitur a.",
                    CategoryID = 1,
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now,
                    ID = 1,
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.Now,
                    Subject = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
                },
                new Post
                {
                    Body = "Nunc sit amet felis ullamcorper, placerat nibh sit amet, facilisis tortor. Nam porta nisi id arcu euismod, at luctus felis tempus. Sed sit amet ultrices lorem. Nulla a est id lectus congue euismod. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Suspendisse cursus malesuada neque, ac scelerisque ipsum volutpat sed. In a tincidunt arcu, sit amet hendrerit felis. Aliquam ac consectetur sapien. Fusce egestas, tortor id ultrices lobortis, leo metus pretium neque, eget dignissim nulla quam quis mauris. Sed facilisis lorem nisl. Nulla eget leo accumsan, placerat tortor id, feugiat sapien.",
                    CategoryID = 1,
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now.AddHours(-10),
                    ID = 2,
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.Now.AddHours(-10),
                    Subject = "Nunc sit amet felis ullamcorper, placerat nibh sit amet, facilisis tortor."
                },
                new Post
                {
                    Body = "Vestibulum ornare viverra turpis finibus consectetur. Cras id suscipit erat. Praesent orci lacus, pellentesque quis porttitor ac, lobortis ut quam. Morbi posuere, turpis ac molestie faucibus, tellus nisl porta dolor, eu elementum mi dolor id diam. Donec vitae luctus sapien, ac pharetra diam. Donec vel ipsum egestas, varius orci pharetra, semper leo. Vivamus sed mi ut leo venenatis suscipit. Phasellus sed lacinia ipsum. Vivamus suscipit posuere efficitur. Curabitur dapibus feugiat velit, at malesuada risus finibus sit amet. Sed aliquet eros ornare nulla feugiat volutpat. Suspendisse imperdiet posuere sapien, vitae rutrum nulla sodales eu.",
                    CategoryID = 1,
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now.AddHours(-16),
                    ID = 3,
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.Now.AddHours(-16),
                    Subject = "Vestibulum ornare viverra turpis finibus consectetur."
                },
                new Post
                {
                    Body = "Fusce ornare tortor orci, ut facilisis orci iaculis nec. Maecenas cursus venenatis sodales. Nunc feugiat aliquet nisl, sit amet consequat dolor consequat ut. Donec scelerisque, urna quis dapibus posuere, sapien mi tristique erat, eget lacinia ante nisl non mi. Nam sit amet mauris bibendum, fermentum dui consequat, ornare tortor. Sed ornare pretium augue, quis consequat ex viverra id. Integer ut ultricies dolor, quis posuere eros. Donec pharetra lectus ut ex bibendum tincidunt a in orci. Donec sodales luctus lacus, nec scelerisque lectus sodales id.",
                    CategoryID = 1,
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now.AddHours(-5),
                    ID = 4,
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.Now.AddHours(-5),
                    Subject = "Fusce ornare tortor orci, ut facilisis orci iaculis nec."
                },
                new Post
                {
                    Body = "Mauris hendrerit aliquam libero ut imperdiet. Aenean semper pellentesque arcu, sed vehicula nibh aliquam id. Etiam nec volutpat nisl. Morbi scelerisque auctor quam, vel ullamcorper nisi viverra a. Donec sed metus vitae libero ornare mollis. Ut suscipit nunc tincidunt posuere rutrum. Praesent enim arcu, tristique sit amet tellus eget, vestibulum varius libero. Vivamus nec sem justo. Nulla sed viverra libero. Fusce interdum velit ut risus volutpat, vitae dapibus purus hendrerit. Sed fringilla auctor nibh, eu bibendum tortor condimentum interdum. Proin in quam tempor, volutpat nisl vel, dapibus ante. Quisque auctor porttitor tincidunt. Donec ornare, ex ut ullamcorper porta, felis dolor mattis lectus, ut placerat nisl enim sollicitudin ex. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.",
                    CategoryID = 1,
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now.AddHours(-8),
                    ID = 5,
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.Now.AddHours(-8),
                    Subject = "Mauris hendrerit aliquam libero ut imperdiet."
                },
                new Post
                {
                    Body = "Donec ut posuere quam. Donec blandit, velit eget cursus hendrerit, nisl est pellentesque lacus, eu semper massa purus in magna. Proin ac nibh quis purus tincidunt mollis ut nec ex. Vestibulum porta nulla ut lectus congue, a pellentesque erat imperdiet. Proin sodales nunc nulla, in cursus ligula laoreet sit amet. Quisque ac diam tortor. Phasellus luctus, turpis in tempor lacinia, augue lectus hendrerit diam, id sollicitudin ligula quam sit amet nisi. Maecenas lobortis mauris ac vestibulum fermentum. Nam venenatis nisl sed sem tincidunt, vel cursus sapien iaculis. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Suspendisse scelerisque hendrerit convallis. Pellentesque pellentesque lacinia lectus ac volutpat.",
                    CategoryID = 1,
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now.AddHours(-2),
                    ID = 6,
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.Now.AddHours(-2),
                    Subject = "Donec ut posuere quam."
                },
                new Post
                {
                    Body = "Cras mattis lobortis sollicitudin. Aliquam egestas vitae erat ac pretium. Donec dictum luctus nisi sed venenatis. Nunc id odio ac ex laoreet lobortis. Vestibulum vel vulputate lacus. Proin vestibulum eu magna a porttitor. Curabitur eget dolor a enim placerat congue.",
                    CategoryID = 1,
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now.AddHours(-2),
                    ID = 6,
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.Now.AddHours(-2),
                    Subject = "Cras mattis lobortis sollicitudin."
                },
                new Post
                {
                    Body = "Vestibulum sagittis, sapien in porta condimentum, lectus urna gravida odio, et hendrerit mauris orci sit amet augue. Interdum et malesuada fames ac ante ipsum primis in faucibus. Nam tempus ultricies erat at rhoncus. Proin faucibus justo sed mauris fringilla imperdiet. Sed sapien ipsum, bibendum non tempor vel, mollis eget eros. Aenean nunc erat, maximus quis gravida a, sodales sed sapien. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec pretium nec ligula ac rutrum. Nulla in auctor massa. Suspendisse sagittis nulla at est ornare, vitae feugiat diam convallis. Proin tincidunt odio sit amet tortor sollicitudin pulvinar. Sed iaculis facilisis enim nec ultricies. Nam condimentum vehicula elit. Integer et varius quam, vitae fringilla leo.",
                    CategoryID = 1,
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now.AddHours(-2),
                    ID = 7,
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.Now.AddHours(-2),
                    Subject = "Vestibulum sagittis, sapien in porta condimentum, lectus urna gravida odio, et hendrerit mauris orci sit amet augue."
                },
                new Post
                {
                    Body = "Vivamus tincidunt nunc urna, vitae sodales sapien tincidunt eu. Donec lacus risus, placerat aliquam posuere eget, hendrerit eu justo. Sed erat nunc, laoreet auctor aliquam eu, maximus aliquam mauris. Cras tincidunt rutrum nulla, ac aliquam nibh suscipit ac. Integer mollis orci at ex venenatis pellentesque. Integer ultricies lacus id lectus sodales dignissim. Morbi libero eros, imperdiet in erat vel, fermentum blandit dui. Phasellus fermentum laoreet tincidunt. Aliquam ac risus diam. Fusce commodo nisi non elit tempus mollis at sit amet justo. Donec pretium ligula nec malesuada mollis. Vivamus laoreet quam ut interdum laoreet",
                    CategoryID = 1,
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now.AddHours(-5),
                    ID = 8,
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.Now.AddHours(-5),
                    Subject = "Vivamus tincidunt nunc urna, vitae sodales sapien tincidunt eu."
                },
            };
        }
    }

    
}
