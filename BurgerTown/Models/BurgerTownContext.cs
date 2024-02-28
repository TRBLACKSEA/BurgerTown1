using BurgerTown.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BurgerTown.Models
{
    public class BurgerTownContext:DbContext
    {
        public BurgerTownContext():base("BurgerTownDBCS") //burgertown db connection  string
        {
          
        }

        public DbSet<Masa> Masalar { get; set; }
        public DbSet<Kategori> Kategoriler{ get; set; }
        public DbSet<Malzeme> Malzemeler { get; set; }
        public DbSet<FisBaslik> FisBaliklari { get; set; }
        public DbSet<FisDetay> FisDetaylari{ get; set; }
        public DbSet<Kampanya> Kampanyalar{ get; set; }
        public DbSet<WebSiteSettings> WebSiteSettings{ get; set; }
        public DbSet<Personel> Personeller{ get; set; }
        public DbSet<GeciciMalzeme> GeciciMalzemeler{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MasaMap());
            modelBuilder.Configurations.Add(new KategoriMap());
            modelBuilder.Configurations.Add(new MalzemeMap());
            modelBuilder.Configurations.Add(new FisBaslikMap());
            modelBuilder.Configurations.Add(new FisDetayMap());
            modelBuilder.Configurations.Add(new KampanyaMap());
            modelBuilder.Configurations.Add(new WebSiteSettingsMap());
            modelBuilder.Configurations.Add(new PersonelMap());
            modelBuilder.Configurations.Add(new GeciciMalzemeMap());
        }

    }
}