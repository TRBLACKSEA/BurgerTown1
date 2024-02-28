using BurgerTown.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace BurgerTown.Controllers
{
    public class AdminController : Controller
    {
        BaseModel baseModel = new BaseModel();
        BurgerTownContext burgerTownContext = new BurgerTownContext();
        // GET: Admin
        public ActionResult Index()
        {
            using (var Context = new BurgerTownContext())//otomatik dispose yapar.
            {
                Context.Database.CreateIfNotExists();
            }
            return View();
        }
        [HttpGet]
        public ActionResult ListCategory()
        {
            baseModel.kategoriler = burgerTownContext.Kategoriler.ToList();
            return View(baseModel);
        }
        [HttpPost]
        public ActionResult ListCategory(int value)
        {
            if (value == 0)
            {
                baseModel.kategoriler = burgerTownContext.Kategoriler.Where(q => q.isMainCategory == true).ToList();
            }
            else if (value == 1)
            {
                baseModel.kategoriler = burgerTownContext.Kategoriler.Where(q => q.isMainCategory == false).ToList();
            }
            else
            {
                baseModel.kategoriler = burgerTownContext.Kategoriler.ToList();
            }

            return View(baseModel);
        }

        [HttpPost]
        public ActionResult AddCategory(Kategori kategori)
        {
            if (kategori.isMainCategory)
            {
                kategori.UpCategoryID = 0;
            }
            burgerTownContext.Kategoriler.Add(kategori);
            burgerTownContext.SaveChanges();
            List<Kategori> kategoriler = burgerTownContext.Kategoriler.ToList();
            return RedirectToAction("ListCategory", "Admin", kategori);
        }
        [HttpGet]
        public ActionResult UpdateCategory(int ID)
        {
            baseModel.guncellencekKategori = burgerTownContext.Kategoriler.Where(q => q.ID == ID).FirstOrDefault();
            baseModel.kategoriler = burgerTownContext.Kategoriler.ToList();
            return View(baseModel);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Kategori kategori)
        {
            Kategori kategori1 = burgerTownContext.Kategoriler.Where(q => q.ID == kategori.ID).FirstOrDefault();
            kategori1.Description = kategori.Description;

            if (kategori.isMainCategory)
            {
                kategori1.UpCategoryID = 0;
            }
            else
            {
                kategori1.UpCategoryID = kategori.UpCategoryID;
            }
            kategori1.isMainCategory = kategori.isMainCategory;
            burgerTownContext.SaveChanges();
            baseModel.kategoriler = burgerTownContext.Kategoriler.ToList();
            return RedirectToAction("ListCategory", "Admin", baseModel);
        }
        [HttpGet]
        public ActionResult DeleteCategory(int ID)
        {
            Kategori silinecekKategori = burgerTownContext.Kategoriler.Where(q => q.ID == ID).FirstOrDefault();
            //Silinecek Kategori için malzeme sayısı kontrolü
            int malzemeSayisi = burgerTownContext.Malzemeler.Where(q => q.CategoryID == ID).ToList().Count;
            if (malzemeSayisi == 0)
            {
                burgerTownContext.Kategoriler.Remove(silinecekKategori);
                burgerTownContext.SaveChanges();
            }
            baseModel.kategoriler = burgerTownContext.Kategoriler.ToList();
            return RedirectToAction("ListCategory", "Admin", baseModel);
        }

        [HttpGet]
        public ActionResult ListMaterials()
        {

            baseModel.malzemeler = burgerTownContext.Malzemeler.ToList();
            return View(baseModel);
        }

        [HttpGet]
        public ActionResult AddMaterial()
        {

            baseModel.malzemeler = burgerTownContext.Malzemeler.ToList();
            baseModel.kategoriler = burgerTownContext.Kategoriler.ToList();
            return View(baseModel);
        }
        [HttpPost]
        public ActionResult AddMaterial(Malzeme malzeme)
        {
            baseModel.malzemeler = burgerTownContext.Malzemeler.ToList();
            baseModel.kategoriler = burgerTownContext.Kategoriler.ToList();
            if (Request.Files.Count > 0 && !string.IsNullOrEmpty(malzeme.ImagePath))
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string yol = "/AdminLTE-3.2.0/dist/MaterialImages/" + dosyaAdi;
                malzeme.ImagePath = yol;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                burgerTownContext.Malzemeler.Add(malzeme);
                burgerTownContext.SaveChanges();
            }
            return RedirectToAction("ListMaterials", "Admin", baseModel);
        }
        [HttpGet]
        public ActionResult UpdateMaterial(int ID)
        {
            baseModel.guncellencekMalzeme = burgerTownContext.Malzemeler.Where(q => q.ID == ID).FirstOrDefault();
            baseModel.malzemeler = burgerTownContext.Malzemeler.ToList();
            baseModel.kategoriler = burgerTownContext.Kategoriler.ToList();
            return View(baseModel);
        }

        [HttpPost]
        public ActionResult UpdateMaterial(Malzeme _malzeme)
        {
            Malzeme malzeme = burgerTownContext.Malzemeler.Where(q => q.ID == _malzeme.ID).FirstOrDefault();
            malzeme.Name = _malzeme.Name;
            malzeme.Description = _malzeme.Description;
            malzeme.Price = _malzeme.Price;
            malzeme.CategoryID = _malzeme.CategoryID;
            malzeme.isUsing = _malzeme.isUsing;
            if (Request.Files.Count > 0 && !string.IsNullOrEmpty(_malzeme.ImagePath))
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string yol = "/AdminLTE-3.2.0/dist/MaterialImages/" + dosyaAdi;
                malzeme.ImagePath = yol;
                Request.Files[0].SaveAs(Server.MapPath(yol));

            }
            burgerTownContext.SaveChanges();
            baseModel.malzemeler = burgerTownContext.Malzemeler.ToList();
            baseModel.kategoriler = burgerTownContext.Kategoriler.ToList();
            return RedirectToAction("ListMaterials", "Admin", baseModel);
        }

        [HttpGet]
        public ActionResult ListTables()
        {
            baseModel.masalar = burgerTownContext.Masalar.ToList();
            return View(baseModel);
        }

        [HttpPost]
        public ActionResult AddTable(Masa masa)
        {
            burgerTownContext.Masalar.Add(masa);
            burgerTownContext.SaveChanges();
            baseModel.masalar = burgerTownContext.Masalar.Where(q => q.isActive == true).ToList();
            return RedirectToAction("ListTables", baseModel);
        }

        public ActionResult ListOffers()
        {
            baseModel.kampanyalar = burgerTownContext.Kampanyalar.Where(q => q.isUsing == true).ToList();
            return View(baseModel);
        }
        [HttpGet]
        public ActionResult AddOffer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddOffer(Kampanya kampanya)
        {
            burgerTownContext.Kampanyalar.Add(kampanya);
            burgerTownContext.SaveChanges();
            baseModel.kampanyalar = burgerTownContext.Kampanyalar.Where(q => q.isUsing == true).ToList();
            return View("ListOffers", baseModel);
        }
        [HttpGet]
        public ActionResult UpdateOffer(int ID)
        {
            baseModel.guncellenecekKampanya = burgerTownContext.Kampanyalar.Where(q => q.ID == ID).FirstOrDefault();
            return View(baseModel);
        }
        [HttpPost]
        public ActionResult UpdateOffer(Kampanya _kampanya)
        {
            Kampanya kampanya = burgerTownContext.Kampanyalar.Where(q => q.ID == _kampanya.ID).FirstOrDefault();
            kampanya.Name = _kampanya.Name;
            kampanya.Description = _kampanya.Description;
            kampanya.Discount = _kampanya.Discount;
            kampanya.isUsing = _kampanya.isUsing;
            burgerTownContext.SaveChanges();
            baseModel.kampanyalar = burgerTownContext.Kampanyalar.Where(q => q.isUsing == true).ToList();
            return RedirectToAction("ListOffers", baseModel);
        }
        public ActionResult ListFiches()
        {
            baseModel.fisBasliklari = burgerTownContext.FisBaliklari.ToList();
            return View(baseModel);
        }
        [HttpGet]
        public ActionResult ShowFiche(int ID)
        {
            baseModel.SecilenFisBaslik = burgerTownContext.FisBaliklari.Where(q => q.ID == ID).FirstOrDefault();
            return View(baseModel);
        }
        [HttpGet]
        public ActionResult ListEmployee()
        {
            baseModel.Personeller = burgerTownContext.Personeller.ToList();
            return View(baseModel);
        }
        [HttpPost]
        public ActionResult ListEmployee(Personel personel)
        {
            burgerTownContext.Personeller.Add(personel);
            burgerTownContext.SaveChanges();
            baseModel.Personeller = burgerTownContext.Personeller.ToList();
            return RedirectToAction("ListEmployee", baseModel);
        }
        [HttpGet]
        public ActionResult UpdateEmployee(int ID)
        {
            baseModel.GuncellenecekPersonel = burgerTownContext.Personeller.Where(q => q.ID == ID).FirstOrDefault();
            return View(baseModel);
        }
        [HttpPost]
        public ActionResult UpdateEmployee(Personel _personel)
        {
            Personel personel = burgerTownContext.Personeller.Where(q => q.ID == _personel.ID).FirstOrDefault();
            personel.Name = _personel.Name;
            personel.Password = _personel.Password;
            personel.isAdmin = _personel.isAdmin;
            burgerTownContext.SaveChanges();
            baseModel.Personeller = burgerTownContext.Personeller.ToList();
            return View("ListEmployee",baseModel);
        }
        [HttpGet]
        public ActionResult UpdateTable(int ID)
        {
            baseModel.guncellencekMasa = burgerTownContext.Masalar.Where(q => q.ID == ID).FirstOrDefault();
            return View(baseModel);
        }
        [HttpPost]
        public ActionResult UpdateTable(Masa _masa)
        {
            Masa guncellenecekMasa = burgerTownContext.Masalar.Where(q => q.ID == _masa.ID).FirstOrDefault();
            guncellenecekMasa.Name = _masa.Name;
            guncellenecekMasa.isActive = _masa.isActive;
            burgerTownContext.SaveChanges();
            return RedirectToAction("ListTables", baseModel);
        }
    }
}