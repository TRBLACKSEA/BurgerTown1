using BurgerTown.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace BurgerTown.Mapping
{
    public class FisBaslikMap : EntityTypeConfiguration<FisBaslik>
    {
        public FisBaslikMap()
        {
            this.HasKey(q=>q.ID);
            this.Property(q => q.ID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(q => q.Toplam).HasPrecision(6, 2);

            this.ToTable("FisBasliklari");
            this.Property(q => q.ID).HasColumnName("ID");
            this.Property(q => q.OrderID).HasColumnName("OrderID");
            this.Property(q => q.TableID).HasColumnName("TableID");
            this.Property(q => q.OrderDate).HasColumnName("OrderDate");
            this.Property(q => q.PurchaseMethod).HasColumnName("PurchaseMethod");
            this.Property(q => q.KDVOrani).HasColumnName("KDVOrani");
            this.Property(q => q.KDVMiktari).HasColumnName("KDVMiktari");
            this.Property(q => q.AraToplam).HasColumnName("AraToplam");
            this.Property(q => q.Toplam).HasColumnName("Toplam");
        }
    }
}