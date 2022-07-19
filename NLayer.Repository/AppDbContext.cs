using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) //Options alınmasının sebebi, veritabanı yolunun                                                              //bir startup üzerinden verilmesini sağlaması
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; } //DbSet veritabanı işlemleri için kullanılır.
        public DbSet<ProductFeature> ProductFeatures { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //tüm configuration dosyalarını okumak için bir assembly metodu kullanılır. Çalıştırılan execute sayfasını okur.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
            {
                Id = 1,
                Color = "Kırmızı",
                Height=100,
                Weight=50,
                ProductId=1
            }, new ProductFeature()
            { 
                Id = 2,
                Color ="Mavi",
                Height =200,
                Weight=150,
                ProductId=2
            } 
            );
            




            base.OnModelCreating(modelBuilder);
        }
    }
}
