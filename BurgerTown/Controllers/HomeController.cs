using BurgerTown.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BurgerTown.Controllers
{
    public class HomeController : Controller
    {
        BurgerTownContext context = new BurgerTownContext();
        BaseModel basemodel = new BaseModel();
        [HttpGet]
        public ActionResult Index()
        {
            basemodel.WebSiteSettings = context.WebSiteSettings.Where(q => q.ID == 1).FirstOrDefault();
            return View(basemodel);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Products()
        {

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}