using RestaurantManager2021.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantManager2021.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRestaurantData _db;

        public HomeController(IRestaurantData db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            var model = _db.GetAll();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}