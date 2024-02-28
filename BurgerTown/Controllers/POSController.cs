using BurgerTown.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BurgerTown.Controllers
{

    public class POSController : Controller
    {
        BurgerTownContext context = new BurgerTownContext();
        BaseModel baseModel = new BaseModel();
        
        public ActionResult POSMenu()
        {
            baseModel.kategoriler = context.Kategoriler.ToList();
            baseModel.malzemeler = context.Malzemeler.Where(q => q.isUsing == true).ToList();
            baseModel.kampanyalar = context.Kampanyalar.Where(q => q.isUsing == true).ToList();
            return View(baseModel);
        }

        [HttpGet]
        public ActionResult AddSelectedToFiche(int ID)
        {
            Malzeme fiseEklenecekMalzeme = context.Malzemeler.Where(q => q.ID == ID).FirstOrDefault();
            BurgerTown.Models.BaseModel.GeciciSiparisFisi.Add(fiseEklenecekMalzeme);
            baseModel.kategoriler = context.Kategoriler.ToList();
            baseModel.malzemeler = context.Malzemeler.Where(q => q.isUsing == true).ToList();
            return RedirectToAction("POSMenu", baseModel);
        }
        [HttpGet]
        public ActionResult DeleteFromFiche(int ID)
        {
            Malzeme fistenSilinecekMalzeme = BurgerTown.Models.BaseModel.GeciciSiparisFisi.Where(q => q.ID == ID).FirstOrDefault();
            BurgerTown.Models.BaseModel.GeciciSiparisFisi.Remove(fistenSilinecekMalzeme);
            baseModel.kategoriler = context.Kategoriler.ToList();
            baseModel.malzemeler = context.Malzemeler.Where(q => q.isUsing == true).ToList();
            return RedirectToAction("POSMenu", baseModel);
        }
        [HttpGet]
        public ActionResult CloseFiche()
        {
            baseModel.kategoriler = context.Kategoriler.ToList();
            baseModel.malzemeler = context.Malzemeler.Where(q => q.isUsing == true).ToList();
            return RedirectToAction("POSMenu", baseModel);
        }
        [HttpGet]
        public ActionResult PrintFiche()
        {
            baseModel.kategoriler = context.Kategoriler.ToList();
            baseModel.malzemeler = context.Malzemeler.Where(q => q.isUsing == true).ToList();
            return RedirectToAction("POSMenu", baseModel);
        }
        public ActionResult Tables()
        {
            baseModel.masalar = context.Masalar.ToList();
            return View(baseModel);
        }
        [HttpGet]
        public ActionResult SelectOffer(int ID)
        {
            BurgerTown.Models.BaseModel.uygulananKampanya = context.Kampanyalar.Where(q => q.ID == ID).FirstOrDefault();
            return RedirectToAction("POSMenu", baseModel);
        }
        [HttpGet]
        public ActionResult CashPurchase()
        {
            FisBaslik fisBaslik = new FisBaslik();
            fisBaslik.OrderID = context.FisBaliklari.ToList().Count + 1;
            fisBaslik.OrderDate = DateTime.Now;
            fisBaslik.TableID = 0;
            fisBaslik.PurchaseMethod =false;
            if (context.FisBaliklari.Add(fisBaslik)!=null)
            {
                context.SaveChanges();
                FisDetay fisDetay = new FisDetay();
                fisDetay.FisBaslikID = fisBaslik.ID;
                string fisIDleri = "";
                foreach (var malzeme in BaseModel.GeciciSiparisFisi)
                {
                    fisIDleri += malzeme.ID + ",";
                }
                fisDetay.Malzemeler = fisIDleri;
                fisDetay.UygulananKampanyaID = BaseModel.uygulananKampanya.ID;
                int FisBaslikSayisi = context.FisBaliklari.ToList().Count;
                FisBaslik _fisBaslik = context.FisBaliklari.OrderBy(c => 1 == 1).Skip(FisBaslikSayisi - 1).FirstOrDefault();
                _fisBaslik.Toplam = BaseModel.FisToplam;
                fisBaslik.KDVOrani = BaseModel.KDVOrani;
                fisBaslik.KDVMiktari = BaseModel.KDVMiktari;
                fisBaslik.AraToplam = BaseModel.AraToplam;
                context.FisDetaylari.Add(fisDetay);
                context.SaveChanges();
                BaseModel.GeciciSiparisFisi.Clear();
                BaseModel.uygulananKampanya = null;
                BaseModel.uygulananKampanya = new Kampanya();
                BaseModel.AraToplam = 0.0m;
                BaseModel.KDVOrani = 0.0m;
                BaseModel.KDVMiktari = 0.0m;
                BaseModel.FisToplam = 0.0m;
            }
            return RedirectToAction("POSMenu", baseModel);
        }
        [HttpGet]
        public ActionResult CardPurchase()
        {
            FisBaslik fisBaslik = new FisBaslik();
            fisBaslik.OrderID = context.FisBaliklari.ToList().Count + 1;
            fisBaslik.OrderDate = DateTime.Now;
            fisBaslik.TableID = 0;
            fisBaslik.PurchaseMethod = true;
            if (context.FisBaliklari.Add(fisBaslik) != null)
            {
                context.SaveChanges();
                FisDetay fisDetay = new FisDetay();
                fisDetay.FisBaslikID = fisBaslik.ID;
                string fisIDleri = "";
                foreach (var malzeme in BaseModel.GeciciSiparisFisi)
                {
                    fisIDleri += malzeme.ID + ",";
                }
                fisDetay.Malzemeler = fisIDleri;
                fisDetay.UygulananKampanyaID = BaseModel.uygulananKampanya.ID;
                int FisBaslikSayisi = context.FisBaliklari.ToList().Count;
                FisBaslik _fisBaslik = context.FisBaliklari.OrderBy(c => 1 == 1).Skip(FisBaslikSayisi - 1).FirstOrDefault();
                _fisBaslik.Toplam = BaseModel.FisToplam;
                fisBaslik.KDVOrani = BaseModel.KDVOrani;
                fisBaslik.KDVMiktari = BaseModel.KDVMiktari;
                fisBaslik.AraToplam = BaseModel.AraToplam;
                context.FisDetaylari.Add(fisDetay);
                context.SaveChanges();
                BaseModel.GeciciSiparisFisi.Clear();
                BaseModel.uygulananKampanya = null;
                BaseModel.uygulananKampanya = new Kampanya();
                BaseModel.AraToplam = 0.0m;
                BaseModel.KDVOrani = 0.0m;
                BaseModel.KDVMiktari = 0.0m;
                BaseModel.FisToplam = 0.0m;
            }
            return RedirectToAction("POSMenu", baseModel);
        }
        [HttpGet]
        public ActionResult AddSelectedToTableFiche(int Parameter1,int Parameter2)
        {
            Malzeme _malzeme = context.Malzemeler.Where(q => q.ID == Parameter1).FirstOrDefault();
            GeciciMalzeme geciciMalzeme = new GeciciMalzeme()
            {
                Name = _malzeme.Name,
                Description = _malzeme.Description,
                ImagePath = _malzeme.ImagePath,
                MaterialID = Parameter1,
                isUsing = _malzeme.isUsing,
                Price = _malzeme.Price,
                TableID = Parameter2
            };
            context.GeciciMalzemeler.Add(geciciMalzeme);
            context.SaveChanges();
            return RedirectToAction("ShowTable", new { ID = Parameter2 });
        }
        [HttpGet]
        public ActionResult CashPurchaseTable(int Parameter1,int Parameter2)
        {

            return RedirectToAction("ShowTable",baseModel);
        }
        public ActionResult RemoveAppliyingCampaign()
        {
            BaseModel.uygulananKampanya = new Kampanya();
            return RedirectToAction("POSMenu", baseModel);
        }
        [HttpGet]
        public ActionResult ShowTable(int ID)
        {
            baseModel.kategoriler = context.Kategoriler.ToList();
            baseModel.malzemeler = context.Malzemeler.Where(q => q.isUsing == true).ToList();
            baseModel.kampanyalar = context.Kampanyalar.Where(q => q.isUsing == true).ToList();
            baseModel.SecilenMasa = context.Masalar.Where(q => q.ID == ID).FirstOrDefault();
            return View(baseModel);
        }

    }
}