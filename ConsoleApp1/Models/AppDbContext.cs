using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Models
{
    class AppDbContext : DbContext
    {
        string connection = "Server=(localdb)\\mssqllocaldb;Database=ConsoleApp1;";      
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberEvent>()
                .HasKey(c => new { c.MemberId, c.EventId });

            modelBuilder.Entity<MemberEvent>()
                .HasOne(s => s.Member)
                .WithMany(c => c.Events)
                .HasForeignKey(s => s.MemberId);

            modelBuilder.Entity<MemberEvent>()
                .HasOne(s => s.Event)
                .WithMany(c => c.Members)
                .HasForeignKey(s => s.EventId);
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
