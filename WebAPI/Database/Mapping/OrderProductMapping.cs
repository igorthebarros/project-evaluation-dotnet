using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Mapping
{
    public class OrderProductMapping : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> entity)
        {
            entity.ToTable("OrderProducts", schema: "webapi_schema");

            entity.HasKey(x => x.Id).HasName("PK_ORDER_PRODUCTS");
            entity.HasIndex(x => x.OrderId).HasDatabaseName("IX_ORDER_PRODUCT_ORDER_ID");

            entity.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("Id");

            entity.Property(x => x.OrderId)
                .IsRequired()
                .HasColumnName("OrderId");

            entity.Property(x => x.ProductId)
                .IsRequired()
                .HasColumnName("ProductId");

            entity.Property(x => x.Quantity)
                .IsRequired()
                .HasColumnName("Quantity");

            entity.Property(x => x.Price)
                .IsRequired()
                .HasColumnName("Price")
                .HasColumnType("decimal(18,2)");

            entity.Property(x => x.CreatedAt)
                .IsRequired()
                .HasColumnName("CreatedAt")
                .HasDefaultValueSql("now()");

            entity.Property(x => x.UpdatedAt)
                .HasColumnName("UpdatedAt");

            entity.HasOne(x => x.Order)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.OrderId);

            entity.HasOne(x => x.Product)
                .WithMany(x => x.OrderProducts)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
