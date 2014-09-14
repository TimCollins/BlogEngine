using System.Collections.Generic;
using System.Web.Mvc;
using BlogEngine.Models.Entities;
using BlogEngine.Models.Repositories;

namespace BlogEngine.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            //var postRepository = new Repository<Post>();
            PostRepository postRepository = new PostRepository();

            List<Post> posts = postRepository.GetPosts(5);

            return View(posts);
        }

    }
}
