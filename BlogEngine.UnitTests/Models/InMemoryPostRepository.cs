using System;
using System.Collections.Generic;
using System.Linq;
using BlogEngine.Models.Entities;
using BlogEngine.Models.Repositories;

namespace BlogEngine.UnitTests.Models
{
    // Using the approach documented here: http://msdn.microsoft.com/en-us/library/ff847525(v=vs.100).aspx
    // Reserving judgement on whether it's a good idea or not.
    internal class InMemoryPostRepository : IPostRepository
    {
        private readonly List<Post> _db = GetTestPosts();

        public List<Post> GetPosts(int count)
        {
            return _db.OrderByDescending(p => p.CreatedOn).Take(count).ToList();
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
                    ID = 1,
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
                    ID = 1,
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
                    ID = 1,
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
                    ID = 1,
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.Now.AddHours(-8),
                    Subject = "Mauris hendrerit aliquam libero ut imperdiet."
                }
            };
        }
    }
}
    