using DorangApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DorangApp.DAL
{
    public class DorangContext : IdentityDbContext<AppUser>
    {
       
        public DbSet<Explore>Explorer { get; set; }
        public DorangContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=CA-R215-PC10\\SQLEXPRESS;database=Dorang1;Trusted_Connection=true;TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
