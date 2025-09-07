using ChatBotResumeBE.Util.Model;
using Microsoft.EntityFrameworkCore;

namespace ChatBotResumeBE.Util.Entity
{
    public class ResumeContext : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }

        public ResumeContext(DbContextOptions<ResumeContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API configurations go here if needed
        }
    }
}
