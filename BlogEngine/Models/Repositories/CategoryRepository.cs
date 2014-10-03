using System.Collections.Generic;
using System.Data.SQLite;
using System.Web.Mvc;
using BlogEngine.Models.DataAccess;
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