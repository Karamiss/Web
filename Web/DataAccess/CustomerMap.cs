using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.Models;

namespace Web.DataAccess
{
    public class CustomerMap : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").UseIdentityAlwaysColumn().IsRequired();
            builder.Property(x => x.CustomerName).HasColumnName("customer_name").HasMaxLength(40).IsRequired();
            builder.Property(x => x.CustomerSurname).HasColumnName("cutomer_surname").HasMaxLength(40).IsRequired();
            builder.Property(x => x.PhoneNumber).HasColumnName("phone_number").HasMaxLength(11).IsRequired();
            builder.Property(x => x.CustomerAccount).HasColumnName("customer_account").IsRequired();

            builder.ToTable("customers", "public");
        }
    }
}
