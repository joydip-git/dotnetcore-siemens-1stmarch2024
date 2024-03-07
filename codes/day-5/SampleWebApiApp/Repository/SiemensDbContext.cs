using Microsoft.EntityFrameworkCore;

namespace SampleWebApiApp.Repository
{
    public class SiemensDbContext : DbContext
    {
        public DbSet<EmployeeInfo> EmployeeInfos { get; set; }

        public SiemensDbContext(DbContextOptions<SiemensDbContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"server=joydip-pc\sqlexpress;database=siemensdb;user id=sa;password=SqlServer@2022;TrustServerCertificate=true");
        //}
    }
}
