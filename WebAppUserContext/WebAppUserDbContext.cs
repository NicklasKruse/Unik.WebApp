using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
        SeedUsers(modelBuilder);


        modelBuilder.Entity<IdentityUser>()
            .Property(u => u.ConcurrencyStamp)
            .HasDefaultValueSql("NEWID()"); // NEWID er en SQL funktion, der genererer en ny GUID. Det her er til ConcurrencyStamp, som er en del af IdentityUser.

        modelBuilder.Entity<IdentityRole>()
            .Property(r => r.ConcurrencyStamp)
            .HasDefaultValueSql("NEWID()"); // ConcurrencyStamp IdentityRole.
    }

    /// <summary>
    /// Seeder roller til databasen
    /// </summary>
    /// <param name="modelBuilder"></param>
    private void SeedRoles(ModelBuilder modelBuilder)
    {
        // Guids til roller
        var medlemRoleId = "9ddd52f5-bfdc-43fa-b5bc-e501e09dc17b";
        var bestyrelseRoleId = "51db585d-dfdb-4905-9c37-508424d019c0";
        var formandRoleId = "08dad08d-70d6-4056-b58f-63685eb1cfb4";

        var roles = new List<IdentityRole>
        {
            new IdentityRole { Id = medlemRoleId, Name = "Medlem", NormalizedName = "MEDLEM", ConcurrencyStamp = Guid.NewGuid().ToString() },
            new IdentityRole { Id = bestyrelseRoleId, Name = "Bestyrelse", NormalizedName = "BESTYRELSE", ConcurrencyStamp = Guid.NewGuid().ToString() },
            new IdentityRole { Id = formandRoleId, Name = "Formand", NormalizedName = "FORMAND", ConcurrencyStamp = Guid.NewGuid().ToString() }
        };

        modelBuilder.Entity<IdentityRole>().HasData(roles);
    }

    /// <summary>
    /// Seeder en specifik bruger til databasen
    /// </summary>
    /// <param name="modelBuilder"></param>
    private void SeedUsers(ModelBuilder modelBuilder)
    {
        var hasher = new PasswordHasher<IdentityUser>();

        // user guid
        var userId = "1b9346c3-fa10-4f98-83ea-33c6b5711ad1";

        var user = new IdentityUser
        {
            Id = userId, 
            UserName = "admin@admin.dk",
            NormalizedUserName = "ADMIN@ADMIN.DK",
            Email = "admin@admin.dk",
            NormalizedEmail = "ADMIN@ADMIN.DK",
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "admin1"),
            SecurityStamp = string.Empty
        };

        modelBuilder.Entity<IdentityUser>().HasData(user);

        var userRole = new IdentityUserRole<string>
        {
            UserId = user.Id,
            RoleId = "08dad08d-70d6-4056-b58f-63685eb1cfb4" // Formand
        };

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRole);
    }
}
