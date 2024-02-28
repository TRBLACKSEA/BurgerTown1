using BurgerTown.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace BurgerTown.Mapping
{
    public class KampanyaMap : EntityTypeConfiguration<Kampanya>
    {
        public KampanyaMap()
        {
            this.HasKey(q => q.ID);
            this.Property(q => q.ID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(q => q.Name).HasMaxLength(100);
            this.Property(q => q.Description).HasMaxLength(100);
            this.Property(q => q.Discount).HasPrecision(6, 2);

            this.ToTable("Kampanyalar");
            this.Property(q => q.ID).HasColumnName("ID");
            this.Property(q => q.Name).HasColumnName("Name");
            this.Property(q => q.Description).HasColumnName("Description");
            this.Property(q => q.isUsing).HasColumnName("isUsing");
            this.Property(q => q.Discount).HasColumnName("Discount");
        }
    }
}