using BurgerTown.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace BurgerTown.Mapping
{
    public class WebSiteSettingsMap : EntityTypeConfiguration<WebSiteSettings>
    {
        public WebSiteSettingsMap()
        {
            this.HasKey(q => q.ID);
            this.Property(q => q.ID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(q => q.Instagram).HasMaxLength(300);
            this.Property(q => q.Twitter).HasMaxLength(300);
            this.Property(q => q.Facebook).HasMaxLength(300);
            this.Property(q => q.Mail).HasMaxLength(300);
            this.Property(q => q.Adress).HasMaxLength(500);
            this.Property(q => q.Keywords).HasMaxLength(1000);

            this.ToTable("WebSiteSettings");
            this.Property(q => q.ID).HasColumnName("ID");
            this.Property(q => q.Instagram).HasColumnName("Instagram");
            this.Property(q => q.Twitter).HasColumnName("Twitter");
            this.Property(q => q.Facebook).HasColumnName("Facebook");
            this.Property(q => q.Mail).HasColumnName("Mail");
            this.Property(q => q.Adress).HasColumnName("Adress");
            this.Property(q => q.Keywords).HasColumnName("Keywords");

        }
    }
}