using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.Models;

namespace Web.DataAccess
{
    public class ProductMap : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").UseIdentityAlwaysColumn().IsRequired();
            builder.Property(x => x.ProductName).HasColumnName("product_name").HasMaxLength(50).IsRequired();
            builder.Property(x => x.ProductSize).HasColumnName("product_size").HasMaxLength(10).IsRequired();
            builder.Property(x => x.PaperType).HasColumnName("type_of_paper").HasMaxLength(10).IsRequired();
            builder.Property(x => x.ProductAmount).HasColumnName("product_amount").IsRequired();
            builder.Property(x => x.ProductPrice).HasColumnName("product_price").IsRequired();

            builder.ToTable("products", "public");
        }
    }
}
