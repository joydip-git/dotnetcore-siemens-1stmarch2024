using Microsoft.EntityFrameworkCore;

namespace EFCorePractice.Repository
{
    public class OrderCustomerDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=joydip-pc\sqlexpress;database=siemensdb;user id=sa;password=SqlServer@2022;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Customer>()
                .ToTable("customers")
                .HasKey(c => c.Id);

            modelBuilder
                .Entity<Customer>()
                .Property<string>(c => c.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(50)")
                .IsRequired();

            modelBuilder
                .Entity<Customer>()
                .Property<string>(c => c.MailId)
                .HasColumnName("email")
                .HasColumnType("varchar(100)")
                .IsRequired();

            modelBuilder
                .Entity<Customer>()
                .Property<long>(c => c.Mobile)
                .HasColumnName("mobileno")
                .HasColumnType("bigint")
                .IsRequired();

            modelBuilder
               .Entity<Order>()
               .ToTable("orders")
               .HasKey(o => o.OrderId);

            modelBuilder
                .Entity<Order>()
                .Property<DateTime>(o=>o.OrderDate)
                .HasColumnName("order_date")
                .HasColumnType("date")
                .HasDefaultValue(DateTime.Now.Date);

            modelBuilder
               .Entity<Order>()
               .Property<decimal>(o => o.OrderAmount)
               .HasColumnName("order_amount")
               .HasColumnType("decimal(18,2)")
               .HasDefaultValue(0);

            modelBuilder
                .Entity<Order>()
                .Property<int>(o => o.CustomerId)
                .HasColumnName("customer_id")
                .HasColumnType("int");                

            modelBuilder
                .Entity<Order>()
                .HasOne(o => o.Customer);
        }
    }
}
