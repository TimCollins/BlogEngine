using System.Web.Mvc;
using BlogEngine.Models.Entities;
using BlogEngine.Models.Repositories;

namespace BlogEngine.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Details(int id)
        {
            User user = RepositoryFactory.UserRepository.GetUserByID(id);
            return View(user);
        }

    }
}
