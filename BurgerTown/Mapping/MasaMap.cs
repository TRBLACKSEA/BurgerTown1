using BurgerTown.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace BurgerTown.Mapping
{
    public class MasaMap:EntityTypeConfiguration<Masa>
    {
        public MasaMap()
        {
            this.HasKey(q => q.ID);
            this.Property(q => q.ID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(q => q.Name).HasMaxLength(30);

            this.ToTable("Masalar");
            this.Property(q => q.ID).HasColumnName("ID");
            this.Property(q => q.Name).HasColumnName("Name");
            this.Property(q => q.Status).HasColumnName("Status");
            this.Property(q => q.isActive).HasColumnName("isActive");
        }

    }
}