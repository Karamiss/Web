using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.Models;

namespace Web.DataAccess
{
    public class OrderMap : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").UseIdentityAlwaysColumn().IsRequired();
            builder.Property(x => x.ProductInfo).HasColumnName("product").IsRequired();
            builder.Property(x => x.Customerinfo).HasColumnName("customer").IsRequired();
            builder.Property(x => x.TotalPrice).HasColumnName("total_price").IsRequired();

            builder.ToTable("orders", "public");
        }
    }
}
