using BlogAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }
       
        public DbSet<Blog>  blogs { get; set; }

        public DbSet<Category> categories { get; set; }

        public DbSet<User> users { get; set; }
    }
}
