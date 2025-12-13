using Microsoft.EntityFrameworkCore;
using DatingApp.Entities;

namespace DatingApp.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options){
        public DbSet<AppUser> Users { get; set; }
    }
}
