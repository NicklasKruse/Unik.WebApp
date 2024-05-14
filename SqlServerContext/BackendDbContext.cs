using Microsoft.EntityFrameworkCore;
using Unik.Domain.Entities;
using Unik.Domain.ValueObjects;

namespace SqlServerContext
{
    public class BackendDbContext : DbContext
    {
        public BackendDbContext(DbContextOptions<BackendDbContext> options) : base(options)
        {

        }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Member> Memberships { get; set; }
        //public DbSet<Room> Rooms { get; set; }
        //public DbSet<Tool> Tools { get; set; }
        //public DbSet<Address> Addresses { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<MemberWithAddress> MemberWithAddress { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configuration.MemberConfiguration()); //Brug specifik konfiguration for Member
            modelBuilder.ApplyConfiguration(new Configuration.BookingConfiguration()); //Brug specifik konfiguration for Booking
            modelBuilder.ApplyConfiguration(new Configuration.InvitationConfiguration()); //Brug specifik konfiguration for Invitation
        }

    }
}
