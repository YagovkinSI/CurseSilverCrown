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

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
