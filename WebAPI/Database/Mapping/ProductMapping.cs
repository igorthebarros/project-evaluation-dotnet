using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {

            entity.ToTable("Product", schema: "webapi_schema");

            entity.HasKey(x => x.Id).HasName("PK_PRODUCT");
            entity.HasIndex(x => x.Name).HasDatabaseName("IX_ORDER_NAME");


            entity.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            entity.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Name");

            entity.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("Description");

            entity.Property(x => x.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)")
                .HasColumnName("Price");

            entity.Property(x => x.IsActive)
                .IsRequired()
                .HasColumnName("IsActive");

            entity.Property(x => x.CreatedAt)
                .IsRequired()
                .HasColumnName("CreatedAt")
                .HasDefaultValueSql("now()");

            entity.Property(x => x.UpdatedAt)
                    .HasColumnName("UpdatedAt");
        }
    }
}
