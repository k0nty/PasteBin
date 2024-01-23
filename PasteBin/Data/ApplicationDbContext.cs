using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PasteBin.Models;

namespace PasteBin.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Users> usersDb { get; set; }
        public DbSet<Pastes> pastesDb { get; set; }
        public DbSet<Views> viewsDb { get; set; }
    }
}
