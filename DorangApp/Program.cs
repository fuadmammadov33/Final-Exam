using DorangApp.DAL;
using DorangApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DorangApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<DorangContext>(opt => { opt.UseSqlServer(builder.Configuration.GetConnectionString("default")); });
            builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 3;
                opt.Lockout.MaxFailedAccessAttempts = 5;
            }).AddEntityFrameworkStores<DorangContext>()
            .AddDefaultTokenProviders();

            builder.Services.AddDbContext<DorangContext>();
            var app = builder.Build();

            app.UseAuthorization();


            app.UseStaticFiles();
            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );
            app.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");

            app.Run();
        }
    }
}
