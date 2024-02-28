using BurgerTown.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace BurgerTown.Mapping
{
    public class KategoriMap : EntityTypeConfiguration<Kategori>
    {
        public KategoriMap()
        {
            this.HasKey(q => q.ID);
            this.Property(q => q.ID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(q => q.Description).HasMaxLength(300);

            this.ToTable("Kategoriler");
            this.Property(q => q.ID).HasColumnName("ID");
            this.Property(q => q.Description).HasColumnName("Description");
            this.Property(q => q.UpCategoryID).HasColumnName("UpCategoryID");
            this.Property(q => q.isMainCategory).HasColumnName("isMainCategory");
        }
    }
}