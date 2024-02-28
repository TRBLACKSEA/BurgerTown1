using BurgerTown.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace BurgerTown.Mapping
{
    public class PersonelMap : EntityTypeConfiguration<Personel>
    {
        public PersonelMap()
        {
            this.HasKey(q => q.ID);
            this.Property(q => q.ID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(q => q.Name).HasMaxLength(100);
            this.Property(q => q.Password).HasMaxLength(300);

            this.ToTable("Personeller");
            this.Property(q => q.ID).HasColumnName("ID");
            this.Property(q => q.Name).HasColumnName("Name");
            this.Property(q => q.Password).HasColumnName("Password");
            this.Property(q => q.isAdmin).HasColumnName("isAdmin");
        }
    }
}