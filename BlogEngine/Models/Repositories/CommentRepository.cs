using System;
using System.Collections.Generic;
using System.Data.SQLite;
using BlogEngine.Models.DataAccess;
using BlogEngine.Models.Entities;

namespace BlogEngine.Models.Repositories
{
    public class CommentRepository
    {
        public List<Comment> GetComments(long postID)
        {
            const string sqlQuery = "SELECT ID, Title, Body, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy " +
                                    "FROM Comment " +
                                    "WHERE PostID = @postID " + 
                                    "ORDER BY CreatedOn DESC ";

            List<Comment> comments = new List<Comment>();

            using (var reader = DbUtil.ExecuteReader(sqlQuery, new SQLiteParameter("@postID", postID)))
            {
                while (reader.Read())
                {
                    comments.Add(ReadComment(reader));
                }
            }

            foreach (Comment comment in comments)
            {
                comment.PostID = postID;
            }            

            return comments;
        }

        private Comment ReadComment(SQLiteDataReader reader)
        {
            return new Comment
            {
                Body = reader.Fetch<string>("Body"),
                CreatedBy = reader.Fetch<long>("CreatedBy"),
                CreatedOn = reader.Fetch<DateTime>("CreatedOn"),
                ID = reader.Fetch<long>("ID"),
                ModifiedBy = reader.Fetch<long>("ModifiedBy"),
                ModifiedOn = reader.Fetch<DateTime>("ModifiedOn"),
                Title = reader.Fetch<string>("Title")
            };
        }
    }
}