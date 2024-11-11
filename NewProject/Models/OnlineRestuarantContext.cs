using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NewProject.Models
{
    public class OnlineRestuarantContext : DbContext
    {
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Tbl_User>()
        //        .HasMany(u => u.Roles)
        //        .WithMany(r => r.Users)
        //        .Map(m =>
        //        {
        //            m.ToTable("UserRoles");
        //            m.MapLeftKey("UserId");
        //            m.MapRightKey("RoleId");
        //        });
        //}

        public virtual DbSet<Tbl_Category> Categories { get; set; }
        public virtual DbSet<Tbl_Product> Products { get; set; }
        public virtual DbSet<Tbl_Order> Orders { get; set; }
        public virtual DbSet<Tbl_OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Tbl_User> Users { get; set; }
        public virtual DbSet<Tbl_Role> Roles { get; set; }
    }
}