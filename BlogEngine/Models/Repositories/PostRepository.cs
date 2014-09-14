using System;
using System.Collections.Generic;
using System.Data.SQLite;
using BlogEngine.Models.DataAccess;
using BlogEngine.Models.Entities;

namespace BlogEngine.Models.Repositories
{
    /// <summary>
    /// An alternative repository implementation not using a generic interface (yet)
    /// </summary>
    public class PostRepository
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
    }
}