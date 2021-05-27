using EF.Model;
using Microsoft.EntityFrameworkCore;

namespace EF.Repository
{
    public class UserContext : DbContext
    {
        public DbSet<User> User{ get; set; }
        public DbSet<Role> Role{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-4B177VT\BUGRA;Database=Company;Integrated Security=True");
        }
    }
}
