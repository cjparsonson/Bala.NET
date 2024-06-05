using Microsoft.EntityFrameworkCore;

namespace Bala.Shared;

public class JournalDbContext : DbContext
{
    public DbSet<JournalEntry> JournalEntries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = Path.Combine(
           Environment.CurrentDirectory, "Journal.db");

        string connection = $"Filename={path}";

        WriteLine($"Connection string: {connection}");

        optionsBuilder.UseSqlite(connection);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<JournalEntry>(entity =>
        {
            entity.HasIndex(e => e.Date);
            entity.HasIndex(e => e.Rating);
        });

        modelBuilder.Entity<JournalEntry>().HasData(
            new JournalEntry
            {
                Id = 1,
                Date = DateTime.Now,
                Rating = 5,
                Comment = "Hello World! This is my first journal entry!"
            },
            new JournalEntry
            {
                Id = 2,
                Date = DateTime.Now.AddDays(-1),
                Rating = 4,
                Comment = "This is my second journal entry! Yesterday was great."
            }
        );
    }
}