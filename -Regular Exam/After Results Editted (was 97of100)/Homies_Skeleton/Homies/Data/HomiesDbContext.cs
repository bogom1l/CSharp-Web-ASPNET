using Homies.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Type = Homies.Data.Models.Type;

namespace Homies.Data
{
    public class HomiesDbContext : IdentityDbContext
    {
        public HomiesDbContext(DbContextOptions<HomiesDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Type>()
                .HasData(new Type()
                {
                    Id = 1,
                    Name = "Animals"
                },
                new Type()
                {
                    Id = 2,
                    Name = "Fun"
                },
                new Type()
                {
                    Id = 3,
                    Name = "Discussion"
                },
                new Type()
                {
                    Id = 4,
                    Name = "Work"
                });

            modelBuilder.Entity<EventParticipant>()
                .HasKey(ep => new { ep.EventId, ep.HelperId });

            modelBuilder.Entity<EventParticipant>()
                .HasOne(ep => ep.Helper)
                .WithMany()
                .HasForeignKey(ep => ep.HelperId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Type> Types { get; set; } = null!;
        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<EventParticipant> EventsParticipants { get; set; } = null!;
    }
}