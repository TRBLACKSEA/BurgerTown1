﻿using BurgerTown.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace BurgerTown.Mapping
{
    public class GeciciMalzemeMap:EntityTypeConfiguration<GeciciMalzeme>
    {
        public GeciciMalzemeMap()
        {
            this.HasKey(q => q.ID);
            this.Property(q => q.ID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(q => q.ImagePath).HasMaxLength(500);
            this.Property(q => q.Name).HasMaxLength(300);
            this.Property(q => q.Description).HasMaxLength(500);
            this.Property(q => q.Price).HasPrecision(6, 2);

            this.ToTable("GeciciMalzemeler");
            this.Property(q => q.ID).HasColumnName("ID");
            this.Property(q => q.MaterialID).HasColumnName("MaterialID");
            this.Property(q => q.ImagePath).HasColumnName("ImagePath");
            this.Property(q => q.Name).HasColumnName("Name");
            this.Property(q => q.Description).HasColumnName("Description");
            this.Property(q => q.isUsing).HasColumnName("isUsing");
            this.Property(q => q.Price).HasColumnName("Price");
            this.Property(q => q.TableID).HasColumnName("TableID");
        }
    }
}