﻿using System;
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

        public List<PostSummary> GetPostSummaries(int count)
        {
            const string sqlQuery = "SELECT p.ID AS PostID, " +
                                    "p.CreatedOn, " +
                                    "c.Name AS CategoryName, " +
                                    "SUBSTR(p.Body, 0, @length) Summary, " +
                                    "p.Subject, " +
                                    "u.ID AS UserID, " +
                                    "u.Name AS UserName " +
                                    "FROM Post p " +
                                    "INNER JOIN Category c ON c.ID = p.CategoryID " +
                                    "INNER JOIN User u ON u.ID = p.CreatedBy " +
                                    "LIMIT @count";

            List<PostSummary> posts = new List<PostSummary>();

            using (var reader = DbUtil.ExecuteReader(sqlQuery, new SQLiteParameter("@length", Constants.PostSummaryLength), new SQLiteParameter("@count", count)))
            {
                while (reader.Read())
                {
                    posts.Add(ReadPostSummary(reader));
                }
            }

            return posts;
        }

        public Post GetPostByID(int id)
        {
            const string sqlQuery = "SELECT ID, CategoryID, Subject, Body, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy " +
                                    "FROM Post " +
                                    "WHERE ID = @id";

            Post post = new Post();

            using (var reader = DbUtil.ExecuteReader(sqlQuery, new SQLiteParameter("@id", id)))
            {
                if (reader.Read())
                {
                    post = ReadPost(reader);
                }
            }

            return post;
        }

        public void UpdatePost(Post post)
        {
            const string sqlQuery = "UPDATE Post " +
                                    "SET CategoryID = @categoryID, " +
                                    "Subject = @subject, " +
                                    "Body = @body, " +
                                    "ModifiedOn = @modifiedOn, " +
                                    "ModifiedBy = @modifiedBy " +
                                    "WHERE ID = @id";
            List<SQLiteParameter> parameters = new List<SQLiteParameter>
            {
                new SQLiteParameter("@categoryID", post.CategoryID),
                new SQLiteParameter("@subject", post.Subject),
                new SQLiteParameter("@body", post.Body),
                new SQLiteParameter("modifiedOn", DateTime.Now),
                new SQLiteParameter("modifiedBy", post.ModifiedBy),
                new SQLiteParameter("@id", post.ID)
            };

            DbUtil.ExecuteNonQuery(sqlQuery, parameters.ToArray());
        }

        public void CreatePost(Post post)
        {
            const string sqlQuery = "INSERT INTO Post(CategoryID, Subject, Body, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy) " + 
                "VALUES (@categoryID, @subject, @body, @createdOn, @createdBy, @modifiedOn, @modifiedBy)";

            // Default to Admin if we don't have a user.
            if (post.CreatedBy == 0)
            {
                post.CreatedBy = 1;
            }

            List<SQLiteParameter> parameters = new List<SQLiteParameter>
            {
                new SQLiteParameter("@categoryID", post.CategoryID),
                new SQLiteParameter("@subject", post.Subject),
                new SQLiteParameter("@body", post.Body),
                new SQLiteParameter("createdOn", DateTime.Now),
                new SQLiteParameter("createdBy", post.CreatedBy),
                new SQLiteParameter("modifiedOn", DateTime.Now),
                new SQLiteParameter("modifiedBy", post.CreatedBy)
            };

            DbUtil.ExecuteNonQuery(sqlQuery, parameters.ToArray());
        }

        public void DeletePostByID(long id)
        {
            const string sqlQuery = "DELETE FROM Post " +
                                    "WHERE ID = @id";

            DbUtil.ExecuteNonQuery(sqlQuery, new SQLiteParameter("@id", id));
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

        private PostSummary ReadPostSummary(SQLiteDataReader reader)
        {
            PostSummary postSummary = new PostSummary
            {
                CategoryName = reader.Fetch<string>("CategoryName"),
                DateDetails = reader.Fetch<DateTime>("CreatedOn").ToDisplayDate(),
                PostID = reader.Fetch<long>("PostID"),
                Subject = reader.Fetch<string>("Subject"),
                Summary = reader.Fetch<string>("Summary"),
                UserID = reader.Fetch<long>("UserID"),
                UserName = reader.Fetch<string>("UserName")
            };

            if (postSummary.Summary.Length == Constants.PostSummaryLength - 1)
            {
                postSummary.Summary += "…";
            }

            return postSummary;
        }
    }
}