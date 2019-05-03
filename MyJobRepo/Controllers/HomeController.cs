using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MyJobRepo.Data;
using MyJobRepo.Models;
using MyJobRepo.Controllers;

namespace MyJobRepo.Controllers
{
    public class HomeController : Controller
    {
        private static readonly MyJobRepoContext db = new MyJobRepoContext();
        private readonly Repository Repo = new Repository(db);

        //private IMapper Mapper;


        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.Host = Request.Headers["Host"];

            return View();
        }
    }
}
