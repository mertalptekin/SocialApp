using SocialMedia.DAL.Models.Data.Entity;
using SocialMedia.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SocialMedia.DAL.Models.Data.Context
{
    public class ProjectContext:DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = @"Server=DESKTOP-3H05M6R\SQLEXPRESS;Database=SocialDB;Integrated Security=True;";
         
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Share> Shares { get; set; }
        public DbSet<ShareImage> ShareImages { get; set; }
        public DbSet<ShareVideo> ShareVideos { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserImage> UserImages { get; set; }
        public DbSet<UserVideo> UserVideos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Add<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Add<ManyToManyCascadeDeleteConvention>();
        }

    }
}