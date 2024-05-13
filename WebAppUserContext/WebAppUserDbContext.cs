using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAppUserContext
{
    public class WebAppUserDbContext : IdentityDbContext<IdentityUser>
    {
        public WebAppUserDbContext(DbContextOptions<WebAppUserDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedRoles(modelBuilder);

            modelBuilder.Entity<IdentityUser>()
            .Property(u => u.ConcurrencyStamp)
            .HasDefaultValueSql("NEWID()"); // NEWID er en SQL funktion, der genererer en ny GUID. Det her er til ConcurrencyStamp, som er en del af IdentityUser.
        }
        /// <summary>
        /// Seeder roller til databasen
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void SeedRoles(ModelBuilder modelBuilder)
        {
            // Define the roles to seed
            var roles = new List<IdentityRole>
        {
            new IdentityRole { Name = "Medlem", NormalizedName = "MEDLEM" },
            new IdentityRole { Name = "Bestyrelse", NormalizedName = "BESTYRELSE" },
            new IdentityRole { Name = "Formand", NormalizedName = "FORMAND" }
        };

            // Add roles to the model
            foreach (var role in roles)
            {
                modelBuilder.Entity<IdentityRole>().HasData(role);
            }
        }
    }
}
