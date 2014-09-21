using System.Web.Mvc;
using BlogEngine.Models.Entities;
using BlogEngine.Models.Repositories;

namespace BlogEngine.Controllers
{
    public class PostController : Controller
    {
        public ActionResult Show(int id)
        {
            int i = 17;

            Post post = RepositoryFactory.PostRepository.GetPostByID(id);

            return View(post);
        }

    }
}
