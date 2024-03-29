﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nlayer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
                builder.HasData(
                new Product 
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "Kalem 1",
                    Price = 100,
                    Stock = 34,
                    CreatedDate = DateTime.Now 
                },

                new Product
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "Kalem 2",
                    Price = 400,
                    Stock = 45,
                    CreatedDate = DateTime.Now
                },


                new Product
                {
                    Id = 3,
                    CategoryId = 1,
                    Name = "Kalem 3",
                    Price = 130,
                    Stock = 24,
                    CreatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 4,
                    CategoryId = 2,
                    Name = "Kitap 1",
                    Price = 130,
                    Stock = 24,
                    CreatedDate = DateTime.Now
                
                },
                new Product
                {
                    Id = 5,
                    CategoryId = 2,
                    Name = "Kitap 2",
                    Price = 130,
                    Stock = 24,
                    CreatedDate = DateTime.Now

                },
                new Product
                {
                    Id = 6,
                    CategoryId = 3,
                    Name = "Defter 2",
                    Price = 130,
                    Stock = 24,
                    CreatedDate = DateTime.Now

                }) ;
        }
    }
}
