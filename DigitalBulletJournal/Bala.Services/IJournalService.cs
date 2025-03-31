using Bala.DataContext.Sqlite;
using Bala.EntityModels.Sqlite;

namespace Bala.Services
{
    public interface IJournalService
    {
        Task<List<JournalEntry>> GetJournalEntriesAsync();
        Task<JournalEntry?> GetJournalEntryByIdAsync(int id);
        Task<JournalEntry> AddJournalEntryAsync(JournalEntry entry);
        Task<JournalEntry> EditJournalEntryAsync(JournalEntry entry);
        Task DeleteJournalEntryAsync(int id);
    }
}
