using Microsoft.EntityFrameworkCore;
using NinjaDev.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaDev.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = " كاميرات", Description = "كاميرات " },
                new Category { Id = 2, Name = "اجهزة منزلية", Description = "اجهزة منزلية" },
                new Category { Id = 3, Name = "الكترونيات", Description = " الكترونيات" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "كاميرا كانون", Price = 1500, Qty = 10, CategoryId = 1 },
                new Product { Id = 2, Name = "كاميرا نيكون", Price = 2000, Qty = 5, CategoryId = 1 },
                new Product { Id = 3, Name = "ثلاجة سامسونج", Price = 3000, Qty = 3, CategoryId = 2 },
                new Product { Id = 4, Name = "غسالة LG", Price = 2500, Qty = 4, CategoryId = 2 },
                new Product { Id = 5, Name = "هاتف ايفون", Price = 4000, Qty = 8, CategoryId = 3 },
                new Product { Id = 6, Name = "هاتف سامسونج", Price = 3500, Qty = 6, CategoryId = 3 }
            );
        }   


    }
}









