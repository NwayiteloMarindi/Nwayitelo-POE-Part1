using Microsoft.EntityFrameworkCore;
using Race_Day.Models;
using Race_Day.Models.Entities;
namespace Race_Day.Data
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Race_Event> race_Events { get; set; }
        public DbSet<Race> races { get; set; }
        public DbSet<Registration> registrations { get; set; }   // = enrolments
        public DbSet<Participant> participant { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Result> results { get; set; }
        public DbSet<UserAccount> accounts { get; set; }

        // NEW — add these
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<ParticipantEvent> ParticipantEvents { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}