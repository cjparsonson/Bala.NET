using Microsoft.EntityFrameworkCore;

namespace Bala.Shared

{
    public class JournalDbContext : DbContext
    {
        public DbSet<JournalEntry> JournalEntries { get; set; } = default!;
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Path.Combine(
                Environment.CurrentDirectory, "Journal.db");

            string connection = $"Filename={path}";

            WriteLine($"Connection: {connection}");

            optionsBuilder.UseSqlite(connection);
        }
    }
}