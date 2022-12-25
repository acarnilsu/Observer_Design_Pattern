using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Observer_Design_Pattern.DAL.Entities;

namespace Observer_Design_Pattern.DAL
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-O6Q5UAT;database=ObserverDb; User Id=sa;Password=1234;");
        }
        public DbSet<Discount> Discounts { get; set; }
    }
}
