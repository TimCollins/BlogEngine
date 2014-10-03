using System.Collections.Generic;
using System.Web.Mvc;

namespace BlogEngine.Models.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        List<SelectListItem> GetCategoriesForDropDown();
    }
}