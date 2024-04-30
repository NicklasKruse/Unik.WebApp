using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAppUserContext
{
    public class WebAppUserDbContext : IdentityDbContext
    {
        public WebAppUserDbContext(DbContextOptions<WebAppUserDbContext> options)
            : base(options)
        {
        }
    }
}
