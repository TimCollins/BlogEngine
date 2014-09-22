using System;
using System.Collections.Generic;
using System.Linq;
using BlogEngine.Models.Entities;
using BlogEngine.Models.Repositories.Interfaces;
using BlogEngine.Models.ViewModels;

namespace BlogEngine.UnitTests
{
    class TestPostRepository : IPostRepository
    {
        private readonly List<Post> _testPosts = GetTestPosts();
        private readonly List<PostSummary> _testPostSummaries = GetTestPostSummaries();

        private static List<PostSummary> GetTestPostSummaries()
        {
            return new List<PostSummary>
            {
                new PostSummary
                {
                    CategoryName = "Uncategoried",
                    DateDetails = "2014-09-14 13:38:30",
                    PostID = 1,
                    Subject = "Test summary 1",
                    Summary = "This is test post 1.",
                    UserID = 1,
                    UserName = "Admin"
                },
                new PostSummary
                {
                    CategoryName = "Uncategoried",
                    DateDetails = "5 mins ago",
                    PostID = 2,
                    Subject = "Test summary 2",
                    Summary = "This is test post 2.",
                    UserID = 1,
                    UserName = "Admin"
                },
                new PostSummary
                {
                    CategoryName = "Uncategoried",
                    DateDetails = "5 mins ago",
                    PostID = 3,
                    Subject = "Test summary 3",
                    Summary = "This is test post 3.",
                    UserID = 1,
                    UserName = "Admin"
                },
                new PostSummary
                {
                    CategoryName = "Uncategoried",
                    DateDetails = "5 mins ago",
                    PostID = 4,
                    Subject = "Test summary 4",
                    Summary = "This is test post 4.",
                    UserID = 1,
                    UserName = "Admin"
                },
                new PostSummary
                {
                    CategoryName = "Uncategoried",
                    DateDetails = "5 mins ago",
                    PostID = 5,
                    Subject = "Test summary 5",
                    Summary = "This is test post 5.",
                    UserID = 1,
                    UserName = "Admin"
                }
            };
        }

        private static List<Post> GetTestPosts()
        {
            return new List<Post>
            {
                new Post
                {
                    Body = "This is test post 1. This is the body text.",
                    CategoryID = 1,
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now,
                    ID = 1,
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.Now,
                    Subject = "Test post 1"
                },
                new Post
                {
                    Body = "This is test post 2. This is the body text.",
                    CategoryID = 1,
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now,
                    ID = 2,
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.Now,
                    Subject = "Test post 2"
                },
                new Post
                {
                    Body = "This is test post 3. This is the body text.",
                    CategoryID = 1,
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now,
                    ID = 3,
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.Now,
                    Subject = "Test post 3"
                },
                new Post
                {
                    Body = "This is test post 4. This is the body text.",
                    CategoryID = 1,
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now,
                    ID = 4,
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.Now,
                    Subject = "Test post 4"
                },
                new Post
                {
                    Body = "This is test post 5. This is the body text.",
                    CategoryID = 1,
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now,
                    ID = 5,
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.Now,
                    Subject = "Test post 5"
                }

            };
        }

        public List<Post> GetPosts(int count)
        {
            return _testPosts.OrderBy(p => p.CreatedOn).Take(count).ToList();
        }

        public List<PostSummary> GetPostSummaries(int count)
        {
            return _testPostSummaries.OrderBy(p => p.PostID).Take(count).ToList();
        }

        public Post GetPostByID(int id)
        {
            // Do nothing at the moment as it's not being tested yet.
            return new Post();
        }

        public void UpdatePost(Post post)
        {
            return;
        }

        public void CreatePost(Post post)
        {
            return;
        }
    }

}
