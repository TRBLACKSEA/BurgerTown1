using BurgerTown.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BurgerTown.Controllers
{
    public class QRMenuController : Controller
    {
        BurgerTownContext context = new BurgerTownContext();
        BaseModel baseModel = new BaseModel();
        public ActionResult Index()
        {
            baseModel.kategoriler = context.Kategoriler.ToList();
            baseModel.malzemeler = context.Malzemeler.ToList();
            return View(baseModel);
        }
    }
}