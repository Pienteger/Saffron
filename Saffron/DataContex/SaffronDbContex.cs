using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SaffronEngine.Basic;
using SaffronEngine.Identity;

namespace Saffron.DataContex
{
    public class SaffronDbContex : IdentityDbContext<AppUser>
    {
        public SaffronDbContex(DbContextOptions<SaffronDbContex> options)
            : base(options)
        {

        }
        public DbSet<MenuItem> Menus { get; set; }
    }
}
