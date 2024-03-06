using EFCoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreApp.Data
{
    public class SiemensDbContext : DbContext
    {
        public DbSet<EmployeeInfo> EmployeeInfos { get; set; }

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
            //model building through Fluent API
            modelBuilder
                .Entity<EmployeeInfo>()
                .ToTable("employeeinfos");

            modelBuilder
                .Entity<EmployeeInfo>()
                .HasKey(e => e.Id)
                .HasName("empid");

            modelBuilder
                .Entity<EmployeeInfo>()
                .Property(e => e.Name)
                .HasColumnName("empname")
                .IsRequired()
                .HasColumnType("varchar(50)");

            modelBuilder
                .Entity<EmployeeInfo>()
                .Property(e => e.Salary)
                .HasColumnName("empsalary")
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);

            modelBuilder
                .Entity<EmployeeInfo>()
                .Property(e => e.Department)
                .HasColumnName("emp_dept")
                .HasColumnType("varchar(20)");
        }
    }
}
