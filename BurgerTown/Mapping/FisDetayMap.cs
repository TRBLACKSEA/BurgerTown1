using BurgerTown.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace BurgerTown.Mapping
{
    public class FisDetayMap:EntityTypeConfiguration<FisDetay>
    {
        public FisDetayMap()
        {
            this.HasKey(q => q.ID);
            this.Property(q => q.ID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(q => q.Malzemeler).HasMaxLength(300);

            this.ToTable("FisDetaylari");
            this.Property(q => q.ID).HasColumnName("ID");
            this.Property(q => q.FisBaslikID).HasColumnName("FisBaslikID");
            this.Property(q => q.Malzemeler).HasColumnName("Malzemeler");
            this.Property(q => q.UygulananKampanyaID).HasColumnName("UygulananKampanyaID");
        }
    }
}