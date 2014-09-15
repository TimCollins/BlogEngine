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
        private List<Post> _db;

        public List<Post> GetPosts(int count)
        {
            //_db = GetTestPosts();
            return _db.OrderByDescending(p => p.CreatedOn).Take(count).ToList();
        }

        public void AddPost(Post post)
        {
            _db.Add(post);
        }

        public void AddPosts(List<Post> posts)
        {
            _db.AddRange(posts);
        }
    }
}
    