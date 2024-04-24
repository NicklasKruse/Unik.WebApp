using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Unik.WebApp.Data
{
    public class WebAppUserDbContext : IdentityDbContext
    {
        public WebAppUserDbContext(DbContextOptions<WebAppUserDbContext> options)
            : base(options)
        {
        }
    }
}
