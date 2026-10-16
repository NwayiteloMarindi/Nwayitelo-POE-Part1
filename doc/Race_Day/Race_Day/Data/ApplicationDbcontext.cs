using Microsoft.EntityFrameworkCore;
using Race_Day.Models;
using Race_Day.Models.Entities;
namespace Race_Day.Data
{
    public class ApplicationDbcontext: DbContext
    {
        public ApplicationDbcontext(DbContextOptions options): base (options)
        {
            
        }
        public DbSet<User> users { get; set; }
        public DbSet<Race_Event> race_Events { get; set; }
        public DbSet<Race> races { get; set; }
        public DbSet<Venue> venues { get; set; }
        public DbSet<Registration> registrations { get; set; }
        public DbSet<Ticket> tickets { get; set; }
        public DbSet<Participant> participant { get; set; }
        public DbSet<Login> logins { get; set; }    
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Race_Day.Models.Entities.Results> results { get; set; }
        public DbSet<UserAccount> accounts { get; set; }
    }
}
