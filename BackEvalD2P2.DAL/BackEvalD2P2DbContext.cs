using BackEvalD2P2.Entity;
using Microsoft.EntityFrameworkCore;

namespace BackEvalD2P2.DAL;

public class BackEvalD2P2DbContext : DbContext
{
    public BackEvalD2P2DbContext(DbContextOptions<BackEvalD2P2DbContext> options) : base(options)
    {
    }
    
    public DbSet<Event> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>()
            .HasKey(e => e.IdEvent);
    }
}