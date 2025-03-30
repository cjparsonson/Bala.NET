using Microsoft.EntityFrameworkCore;
using Bala.EntityModels.Sqlite;

namespace Bala.DataContext.Sqlite;

public partial class JournalDbContext : DbContext
{
    public JournalDbContext()
    {
    }

    public JournalDbContext(DbContextOptions<JournalDbContext> options)
        : base(options)
    {
    }

    public DbSet<JournalEntry> JournalEntries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = String.Empty;

        string database = "Journal.db";
        path = Path.Combine("..", database);
        path = Path.GetFullPath(path);
        JournalContextLogger.WriteLine($"Database path: {path}");

        if (!File.Exists(path))
        {
            JournalContextLogger.WriteLine("Database does not exist.");
        }
        optionsBuilder.UseSqlite($"Data Source={path}");
        optionsBuilder.LogTo(JournalContextLogger.WriteLine,
            new[] { Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting });
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
                Date = new DateTime(2025, 3, 5, 12, 0, 0), // Fixed for migration
                Rating = 5,
                Comment = "Hello World! This is my first journal entry!"
            },
            new JournalEntry
            {
                Id = 2,
                Date = new DateTime(2025, 3, 4, 12, 0, 0), // Fixed for migration
                Rating = 4,
                Comment = "This is my second journal entry! Yesterday was great."
            }
        );
    }
}