using System.Web;
using System.Web.Mvc;
using BlogEngine.Models.Entities;
using BlogEngine.Models.Repositories;

namespace BlogEngine.Controllers
{
    public class PostController : Controller
    {
        public ActionResult Show(int id)
        {
            Post post = RepositoryFactory.PostRepository.GetPostByID(id);

            return View(post);
        }

        public ActionResult Edit(int id)
        {
            Post post = RepositoryFactory.PostRepository.GetPostByID(id);

            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(Post post)
        {
            post.Body = HttpUtility.HtmlDecode(post.Body);
            RepositoryFactory.PostRepository.UpdatePost(post);

            return RedirectToAction("Index", "Home", null);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Post post)
        {
            post.Body = HttpUtility.HtmlDecode(post.Body);
            RepositoryFactory.PostRepository.CreatePost(post);

            return RedirectToAction("Index", "Home", null);
        }
    }
}
