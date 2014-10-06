using System.Web.Mvc;
using BlogEngine.Models.ViewModels;

namespace BlogEngine.Controllers
{
    public class URLController : Controller
    {
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AddURLViewModel userInput)
        {
            if (ModelState.IsValid)
            {
                // Save data
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

    }
}
