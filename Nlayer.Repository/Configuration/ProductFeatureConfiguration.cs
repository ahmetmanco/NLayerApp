using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nlayer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Repository.Configuration
{
    internal class ProductFeatureConfiguration : IEntityTypeConfiguration<ProductFeture>
    {
        public void Configure(EntityTypeBuilder<ProductFeture> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).UseIdentityColumn();
            builder.HasOne(x => x.Product).WithOne(x => x.ProductFeture).HasForeignKey<ProductFeture>(x => x.ProductId);
        }
    }
}
