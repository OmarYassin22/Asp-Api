using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Models.Oreder_Aggregate;

namespace Talabat.Repo.Data.Configurations.Order_Conf
{
    internal class OrderItemConf : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.OwnsOne(item => item.Product, product => product.WithOwner());
            builder.Property(item => item.Price)
                .HasColumnType("decimal(12,2)");
        }
    }
}
