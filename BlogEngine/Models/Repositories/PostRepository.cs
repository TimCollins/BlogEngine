using System;
using System.Collections.Generic;
using System.Data.SQLite;
using BlogEngine.Models.DataAccess;
using BlogEngine.Models.Entities;
using BlogEngine.Models.Repositories.Interfaces;
using BlogEngine.Models.ViewModels;

namespace BlogEngine.Models.Repositories
{
    /// <summary>
    /// An alternative repository implementation not using a generic interface (yet)
    /// </summary>
    public class PostRepository : IPostRepository
    {
        public List<Post> GetPosts(int count)
        {
            const string sqlQuery = "SELECT ID, CategoryID, Subject, Body, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy " + 
                                    "FROM Post " + 
                                    "ORDER BY CreatedOn DESC " + 
                                    "LIMIT @count";

            List<Post> posts = new List<Post>();


            using (var reader = DbUtil.ExecuteReader(sqlQuery, new SQLiteParameter("@count", count)))
            {
                while (reader.Read())
                {
                    posts.Add(ReadPost(reader));
                }
            }

            return posts;
        }

        private Post ReadPost(SQLiteDataReader reader)
        {
            return new Post
            {
                Body = reader.Fetch<string>("Body"),
                CategoryID = reader.Fetch<long>("CategoryID"),
                CreatedBy = reader.Fetch<long>("CreatedBy"),
                CreatedOn = reader.Fetch<DateTime>("CreatedOn"),
                ID = reader.Fetch<long>("ID"),
                ModifiedBy = reader.Fetch<long>("ModifiedBy"),
                ModifiedOn = reader.Fetch<DateTime>("ModifiedOn"),
                Subject = reader.Fetch<string>("Subject")
            };
        }

        public List<PostSummary> GetPostSummaries(int count)
        {
            const string sqlQuery = "SELECT p.ID AS PostID, " +
                                    "p.CreatedOn, " +
                                    "c.Name AS CategoryName, " +
                                    "p.Body, " +
                                    "p.Subject, " +
                                    "u.ID AS UserID, " +
                                    "u.Name AS UserName " +
                                    "FROM Post p " +
                                    "INNER JOIN Category c ON c.ID = p.CategoryID " +
                                    "INNER JOIN User u ON u.ID = p.CreatedBy " +
                                    "LIMIT @count";

            List<PostSummary> posts = new List<PostSummary>();


            using (var reader = DbUtil.ExecuteReader(sqlQuery, new SQLiteParameter("@count", count)))
            {
                while (reader.Read())
                {
                    posts.Add(ReadPostSummary(reader));
                }
            }

            return posts;
        }

        private PostSummary ReadPostSummary(SQLiteDataReader reader)
        {
            return new PostSummary
            {
                CategoryName = reader.Fetch<string>("CategoryName"),
                // Create an extension method?
                DateDetails = reader.Fetch<DateTime>("CreatedOn").ToShortDateString(),
                PostID = reader.Fetch<long>("PostID"),
                Subject = reader.Fetch<string>("Subject"),
                // This should be the first 120 chars or something.
                Summary = reader.Fetch<string>("Body"),
                UserID = reader.Fetch<long>("UserID"),
                UserName = reader.Fetch<string>("UserName")
            };
        }
    }
}