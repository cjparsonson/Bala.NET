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

        public Task<JournalEntry> AddJournalEntryAsync(JournalEntry entry)
        {
            _db.JournalEntries.Add(entry);
            _db.SaveChangesAsync();
            return Task.FromResult(entry);
        }

        public Task<JournalEntry> EditJournalEntryAsync(JournalEntry entry)
        {
            _db.Entry(entry).State = EntityState.Modified;
            _db.SaveChangesAsync();
            return Task.FromResult(entry);
        }

        public Task DeleteJournalEntryAsync(int id)
        {
            JournalEntry? entry = _db.JournalEntries.FirstOrDefaultAsync(e => e.Id == id).Result;
            if (entry == null)
            {
                return Task.CompletedTask;
            }
            else
            {
                _db.JournalEntries.Remove(entry);
                return _db.SaveChangesAsync();
            }
        }

    }
}