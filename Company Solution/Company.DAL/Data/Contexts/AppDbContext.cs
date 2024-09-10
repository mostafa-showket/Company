using Company.DAL.Data.Configurations;
using Company.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Company.DAL.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new DepartmenConfigurations());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server = .; Database = CompanyMVC; Trusted_Connection = True; TrustServerCertificate = True;");
        //}

        public DbSet<Department> Departments { get; set; }
    }
}
