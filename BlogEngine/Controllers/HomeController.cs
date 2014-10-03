using System.Collections.Generic;
using System.Web.Mvc;
using BlogEngine.Models.Repositories;
using BlogEngine.Models.ViewModels;

namespace BlogEngine.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<PostSummary> posts = RepositoryFactory.PostRepository.GetPostSummaries(5);

            return View(posts);
        }
    }
}
