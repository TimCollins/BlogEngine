using System;
using System.Data.SQLite;
using BlogEngine.Models.DataAccess;
using BlogEngine.Models.Entities;
using BlogEngine.Models.Repositories.Interfaces;

namespace BlogEngine.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User GetUserByID(int id)
        {
            const string sqlQuery = "SELECT Name, CreatedOn " +
                                    "FROM User " +
                                    "WHERE ID = @id";

            User user = new User();

            using (var reader = DbUtil.ExecuteReader(sqlQuery, new SQLiteParameter("@id", id)))
            {
                if (reader.Read())
                {
                    user = ReadUser(reader);
                }
            }

            user.ID = id;

            return user;
        }

        private User ReadUser(SQLiteDataReader reader)
        {
            User user = new User
            {
                Name = reader.Fetch<string>("Name"),
                CreatedOn = reader.Fetch<DateTime>("CreatedOn")
            };
            
            return user;
        }
    }
}