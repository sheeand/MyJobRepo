using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyJobRepo.Data;

namespace MyJobRepo.Controllers
{
    public class HomeController : Controller
    {
        private static readonly MyJobRepoContext db = new MyJobRepoContext();
        private readonly Repository Repo = new Repository(db);

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.Host = Request.Headers["Host"];

            return View();
        }
    }
}
