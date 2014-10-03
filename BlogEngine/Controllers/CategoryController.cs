using System.Web.Mvc;
using BlogEngine.Models.Entities;
using BlogEngine.Models.Repositories;

namespace BlogEngine.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult Show(int id)
        {
            Category category = RepositoryFactory.CategoryRepository.GetCategoryByID(id);

            return View(category);
        }

    }
}
