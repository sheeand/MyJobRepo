using System.Web.Mvc;

namespace MyJobRepo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.Host = "localhost:56097";

            return View();
        }
    }
}
