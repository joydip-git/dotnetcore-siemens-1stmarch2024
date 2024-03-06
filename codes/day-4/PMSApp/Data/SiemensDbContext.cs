using Microsoft.EntityFrameworkCore;

namespace PMSApp.Data
{
    public class SiemensDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public SiemensDbContext(DbContextOptions<SiemensDbContext> options)
            :base(options)
        {
            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"server=joydip-pc\sqlexpress;database=siemensdb;user id=sa;password=SqlServer@2022;TrustServerCertificate=true");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Category>()
                .ToTable("categories");

            modelBuilder
                .Entity<Category>()
                .HasKey(c => c.Id);

            modelBuilder
                .Entity<Category>()
                .Property(c => c.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(20)")
                .IsRequired();

            modelBuilder
                .Entity<Product>()
                .ToTable("products")
                .HasKey(p => p.Id);

            modelBuilder
                .Entity<Product>()
                .Property<string>(p => p.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(50)")
                .IsRequired();

            modelBuilder
                .Entity<Product>()
                .Property<decimal>(p => p.Price)
                .HasColumnName("price")
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);

            modelBuilder
                .Entity<Product>()
                .Property<string>(p => p.Description)
                .HasColumnName("description")
                .HasColumnType("varchar(max)");

            modelBuilder
                .Entity<Product>()
                .Property<int?>(p => p.CategoryId)
                .HasColumnName("category_id")
                .HasColumnType("int");

            modelBuilder
                .Entity<Product>()
                .HasOne(p => p.Category);
        }
    }
}
