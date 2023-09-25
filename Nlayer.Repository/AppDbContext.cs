using Microsoft.EntityFrameworkCore;
using Nlayer.Core.Entities;
using Nlayer.Repository.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeture> ProductFetures { get; set; }

        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReferance)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReferance.CreatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                entityReferance.UpdateDate = DateTime.Now; break;
                            }
                    }
                }
            }
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if(item.Entity is BaseEntity entityReferance)
                {
                    switch(item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReferance.CreatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                entityReferance.UpdateDate = DateTime.Now; break;
                            }
                    }
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ProductFeture>().HasData(new ProductFeture()
            {
                Id = 1,
                Color = "Mor",
                Height = 12,
                Width = 8,
                ProductId = 1

            },
            new ProductFeture()
            {
                Id = 2,
                Color = "Mavi",
                Height = 14,
                Width = 9,
                ProductId = 2

            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
