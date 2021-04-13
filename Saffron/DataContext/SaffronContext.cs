using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Saffron.Areas.Identity.Data;
using SaffronEngine.Basic;
using SaffronEngine.Blog;

namespace Saffron.DataContext
{
    public class SaffronContext : IdentityDbContext<SaffronUser>
    {
        public SaffronContext(DbContextOptions<SaffronContext> options)
            : base(options)
        {
        }
        public DbSet<MenuItem> Menus { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<PostTag> PostTags{ get; set; }
        public DbSet<PostCategory> PostCategories  { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BlogPost>().HasIndex(x => x.Title).IsUnique();
            base.OnModelCreating(builder);
        }
    }
}
