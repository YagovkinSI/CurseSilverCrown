using CurseSilverCrown.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurseSilverCrown.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Province> Provinces { get; set; }
        public DbSet<User_Province> User_Province { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            CreateUser_ProvinceLinks(builder);
        }

        private void CreateUser_ProvinceLinks(ModelBuilder builder)
        {
            var model = builder.Entity<User_Province>();
            model.HasKey(e => new { e.ProvinceId, e.UserId });
            model.HasOne(e => e.User)
                .WithOne(e => e.User_Province)
                .OnDelete(DeleteBehavior.Restrict);
            model.HasOne(e => e.Province)
                .WithOne(e => e.User_Province)
                .OnDelete(DeleteBehavior.Cascade);
            model.HasIndex(e => e.UserId).IsUnique();
            model.HasIndex(e => e.ProvinceId).IsUnique();
        }
    }
}
