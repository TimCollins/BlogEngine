using System.Collections.Generic;
using System.Web.Mvc;
using BlogEngine.Models.Entities;

namespace BlogEngine.Models.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        List<SelectListItem> GetCategoriesForDropDown();
        Category GetCategoryByID(int id);
    }
}