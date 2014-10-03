using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Web.Mvc;
using BlogEngine.Models.DataAccess;
using BlogEngine.Models.Entities;
using BlogEngine.Models.Repositories.Interfaces;

namespace BlogEngine.Models.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public List<SelectListItem> GetCategoriesForDropDown()
        {
            const string sqlQuery = "SELECT ID, Name " +
                                    "FROM Category " +
                                    "ORDER BY Name";
            List<SelectListItem> categories = new List<SelectListItem>();

            using (var reader = DbUtil.ExecuteReader(sqlQuery))
            {
                while (reader.Read())
                {
                    categories.Add(ReadSelectListItem(reader));
                }
            }

            return categories;
        }

        public Category GetCategoryByID(int id)
        {
            const string sqlQuery = "SELECT ID, Name, CreatedOn " +
                                    "FROM Category " +
                                    "WHERE ID = @id";
            Category category = new Category();

            using (var reader = DbUtil.ExecuteReader(sqlQuery, new SQLiteParameter("@id", id)))
            {
                if (reader.Read())
                {
                    category = ReadCategory(reader);
                }
                
            }

            return category;
        }

        private Category ReadCategory(SQLiteDataReader reader)
        {
            return new Category
            {
                ID = reader.Fetch<long>("ID"),
                Name = reader.Fetch<string>("Name"),
                CreatedOn = reader.Fetch<DateTime>("CreatedOn")
            };
        }

        private SelectListItem ReadSelectListItem(SQLiteDataReader reader)
        {
            return new SelectListItem
            {
                Value = reader.Fetch<long>("ID").ToString(),
                Text = reader.Fetch<string>("Name")
            };
        }
    }
}