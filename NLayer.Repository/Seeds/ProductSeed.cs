﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product{ Id = 1, CategoryId = 1,Name="Kitap1" ,Price = 100, Stock = 20 , CreatedDate=DateTime.Now},
                new Product { Id = 2, CategoryId = 1, Name = "Kitap2", Price = 250, Stock = 120, CreatedDate = DateTime.Now },
                new Product { Id = 3, CategoryId = 2,Name = "Defter1" ,Price = 150, Stock = 210 , CreatedDate = DateTime.Now},
                new Product { Id = 4, CategoryId = 3, Name = "Kalem1", Price = 100, Stock = 220, CreatedDate = DateTime.Now },
                new Product { Id = 5, CategoryId = 3, Name = "Kalem2", Price = 400, Stock = 30, CreatedDate = DateTime.Now });
        }
    }
}
