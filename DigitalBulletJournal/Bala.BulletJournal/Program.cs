using Microsoft.EntityFrameworkCore; // DbContext, DbSet<T>
using Bala.Shared; // JournalEntry

using (JournalDbContext db = new())
{
    bool deleted = await db.Database.EnsureDeletedAsync();
    WriteLine($"Database deleted: {deleted}");

    bool created = await db.Database.EnsureCreatedAsync();
    WriteLine($"Database created: {created}");

    WriteLine("SQL script used to create the database:");
    WriteLine(db.Database.GenerateCreateScript());

    foreach (JournalEntry entry in db.JournalEntries)
    {
        WriteLine($"Journal entry: {entry.Date:d} {entry.Rating} {entry.Comment}");
    }
}


