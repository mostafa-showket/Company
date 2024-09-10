using Company.DAL.Data.Configurations;
using Company.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Company.DAL.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new DepartmenConfigurations());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .; Database = CompanyMVC; Trusted_Connection = True; TrusServerCertificate = True;");
        }

        public DbSet<Department> Departments { get; set; }
    }
}
