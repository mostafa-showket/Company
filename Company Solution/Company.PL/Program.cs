using Company.BLL;
using Company.DAL.Data.Contexts;
using Company.DAL.Models;
using Company.PL.Mapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Company.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //builder.Services.AddScoped<AppDbContext>(); // Allow DI for AppDbContext
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            }); // Allow DI for AppDbContext
            //builder.Services.AddScoped<IDepartmentRespository, DepartmentRepositry>();
            //builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IUnitOfwork, UnitOfWork>();
            builder.Services.AddAutoMapper(typeof(EmployeeProfile));

            //builder.Services.AddScoped<IScopedService, ScopedService>();            // LifeTime Per Request
            //builder.Services.AddTransient<ITransientService, TransientService>();   // LifeTime Per Operation
            //builder.Services.AddSingleton<ISingletonService, SingletonService>();   // LifeTime Per Application

            //builder.Services.AddScoped<UserManager<ApplicationUser>>();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
