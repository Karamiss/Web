using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.Models;

namespace Web.DataAccess
{
    public class AccountMap : IEntityTypeConfiguration<Accounts>
    {
        public void Configure(EntityTypeBuilder<Accounts> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").UseIdentityAlwaysColumn().IsRequired();
            builder.Property(x => x.Username).HasColumnName("username").HasMaxLength(35).IsRequired();
            builder.Property(x => x.Password).HasColumnName("pass").HasMaxLength(35).IsRequired();
           
            builder.ToTable("accounts", "public");
        }
    }
}
