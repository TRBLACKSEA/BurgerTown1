using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BurgerTown.Models
{
    public class BaseModel
    {
        public BurgerTownContext context = new BurgerTownContext();
        
        public List<Kategori> kategoriler = new List<Kategori>();
        public Kategori guncellencekKategori;

        public List<Malzeme> malzemeler = new List<Malzeme>();
        public Malzeme guncellencekMalzeme;

        public List<Masa> masalar = new List<Masa>();
        public Masa guncellencekMasa;

        public Malzeme secilenMalzeme;

        public static List<Malzeme> GeciciSiparisFisi = new List<Malzeme>();
        public static Kampanya uygulananKampanya = new Kampanya();
        public static decimal KDVOrani = 0.0m;
        public static decimal KDVMiktari = 0.0m;
        public static decimal AraToplam = 0.0m;
        public static decimal FisToplam=0.0m;

        public List<Kampanya> kampanyalar = new List<Kampanya>();
        public Kampanya guncellenecekKampanya;

        public WebSiteSettings WebSiteSettings = new WebSiteSettings();

        public List<FisBaslik> fisBasliklari = new List<FisBaslik>();
        public FisBaslik SecilenFisBaslik;

        public Masa SecilenMasa = new Masa();

        public List<Personel> Personeller = new List<Personel>();
        public Personel GuncellenecekPersonel;

    }
}