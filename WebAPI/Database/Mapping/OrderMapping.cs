using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Mapping
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.ToTable("Orders", schema: "webapi_schema");

            entity.HasKey(x => x.Id).HasName("PK_ORDER");
            entity.HasIndex(x => x.UserId).HasDatabaseName("IX_ORDER_USER_ID");

            entity.Property(x => x.ClientId)
                .IsRequired()
                .HasColumnName("ClientId");

            entity.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("Id");

            entity.Property(x => x.Status)
                .IsRequired()
                .HasMaxLength(1)
                .HasColumnName("Status");

            entity.Property(x => x.Tax)
                .IsRequired()
                .HasColumnName("Tax");

            entity.HasOne(x => x.User)
                .WithMany(x => x.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.Property(x => x.CreatedAt)
                .IsRequired()
                .HasColumnName("CreatedAt")
                .HasDefaultValueSql("now()");

            entity.Property(x => x.UpdatedAt)
                .HasColumnName("UpdatedAt");
        }
    }
}
