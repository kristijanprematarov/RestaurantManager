using RestaurantManager2021.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantManager2021.Web.Controllers
{
    public class GreetingController : Controller
    {
        // GET: Greeting
        public ActionResult Index(string name)
        {
            var model = new GreetingViewModel();
            model.Name = name ?? " => no name is added to query string";
            model.Message = ConfigurationManager.AppSettings.Get("message");
            return View(model);
        }
    }
}