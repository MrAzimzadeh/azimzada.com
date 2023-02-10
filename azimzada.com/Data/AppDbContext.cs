using azimzada.com.Models;
using Microsoft.EntityFrameworkCore;

namespace azimzada.com.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<AnimatedText> AnimatedText { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<Demo> Demos { get; set; }
        public DbSet<Introduction> Introductions { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Work> Works { get; set; }

        

    }
}