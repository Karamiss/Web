using Microsoft.EntityFrameworkCore;
using Web.DataAccess;
using Web.Models;

namespace Web.Data
{
    public class SDbContext : DbContext
    {
        public SDbContext(DbContextOptions options) : base(options)
        {
        }

        //Dbset
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Код выполняет конфигурацию модели данных для создания базы данных.
            base.OnModelCreating(modelBuilder);
            //Метод ApplyConfiguration() применяет указанную конфигурацию для соответствующей сущности модели данных.
            //Это позволяет настроить свойства каждой сущности, установить соответствующие ограничения, реализовать связи между сущностями и др.
            modelBuilder.ApplyConfiguration(new AccountMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
        }
    }
}
