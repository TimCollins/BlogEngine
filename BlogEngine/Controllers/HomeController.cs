using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Mvc;
using BlogEngine.Models.Entities;
using BlogEngine.Models.Repositories;
using BlogEngine.Models.ViewModels;

namespace BlogEngine.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostRepository _postRepository;

        /// <summary>
        /// Define a parameterless constructor which simply uses the default implementation
        /// of PostRepository.
        /// </summary>
        public HomeController() : this(new PostRepository())
        {
            
        }

        /// <summary>
        /// Use constructor injection to define the repository. This will be used by unit
        /// tests to pass in the mock repository.
        /// </summary>
        /// <param name="repository"></param>
        public HomeController(IPostRepository repository)
        {
            _postRepository = repository;
        }

        //
        // GET: /Home/
        public ActionResult Index()
        {
            // This should really use the PostSummary object but let's get it done with Post
            // first and then apply the same technique to PostSummary.

            //PostRepository postRepository = new PostRepository();
            //List<PostSummary> posts = postRepository.GetPostSummaries(5);

            // Do we really have to do this just to satisfy a unit test?
            const string viewName = "Index";
            ViewData["ControllerName"] = viewName;

            List<Post> posts = _postRepository.GetPosts(5);

            return View(viewName, posts);
        }

    }
}
