using Bala.EntityModels.Sqlite;
using Bala.DataContext.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bala.Services
{
    public class JournalService : IJournalService
    {
        private readonly JournalDbContext _db;
        public JournalService(JournalDbContext db)
        {
            _db = db;
        }

        public async Task<List<JournalEntry>> GetJournalEntriesAsync()
        {
            return await _db.JournalEntries.ToListAsync();
        }

        public async Task<JournalEntry?> GetJournalEntryByIdAsync(int id)
        {
            return await _db.JournalEntries.FindAsync(id);
        }

        public async Task AddJournalEntryAsync(JournalEntry entry)
        {
            _db.JournalEntries.Add(entry);
            await _db.SaveChangesAsync();
        }

        public async Task EditJournalEntryAsync(JournalEntry entry)
        {
            _db.JournalEntries.Update(entry);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteJournalEntryAsync(JournalEntry entry)
        {
            _db.JournalEntries.Remove(entry);
            await _db.SaveChangesAsync();
        }

    }
}