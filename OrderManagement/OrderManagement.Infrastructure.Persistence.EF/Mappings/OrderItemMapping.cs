using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagement.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Infrastructure.Persistence.EF.Mappings
{
    public class OrderItemMapping : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem").HasKey(a => a.Id);
            builder.Property<int>("ProductId")
            .IsRequired();
            //builder.OwnsOne(a => a.ProductId)
               // .Property(p => p.Value).HasColumnName("ProductId");

        }
    }
}
