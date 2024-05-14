using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Models.Oreder_Aggregate;

namespace Talabat.Repo.Data.Configurations.Order_Conf
{
    internal class OrderConfi : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(order => order.ShippingAddress, ShippingAddress => ShippingAddress.WithOwner());
            builder.Property(order => order.Status).
                HasConversion(
                (OStatus) => OStatus.ToString(),
                OStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), OStatus));
            builder.Property(order => order.SubTotal)
                .HasColumnType("decimal(12,2)");
            builder.HasOne(order=>order.DeliveryMethod).WithMany().OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(order=>order.Items).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
