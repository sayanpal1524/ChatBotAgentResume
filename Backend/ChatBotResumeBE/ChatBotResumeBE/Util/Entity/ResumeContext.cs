using ChatBotResumeBE.Util.Model;
using Microsoft.EntityFrameworkCore;

namespace ChatBotResumeBE.Util.Entity
{
    public class ResumeContext : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Education> Educations { get; set; }

        public ResumeContext(DbContextOptions<ResumeContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API configurations go here if needed
            modelBuilder.Entity<Experience>()
            .HasOne(p => p.Profile)
            .WithMany(s => s.Experiences)
            .HasForeignKey(c => c.ProfileId);

            modelBuilder.Entity<Education>()
                .HasOne(p => p.Profile)
                .WithMany(s => s.Educations)
                .HasForeignKey(c => c.ProfileId);
        }
    }
}
