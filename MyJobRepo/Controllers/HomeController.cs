using System.Web.Mvc;
using MyJobRepo.DataAccess;

namespace MyJobRepo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.Host = Request.Headers["Host"];

            return View();
        }
    }
}
