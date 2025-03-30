using Bala.DataContext.Sqlite;
using Bala.EntityModels.Sqlite;

namespace Bala.Services
{
    public interface IJournalService
    {
        Task<List<JournalEntry>> GetJournalEntriesAsync();
        Task<JournalEntry?> GetJournalEntryByIdAsync(int id);
        Task AddJournalEntryAsync(JournalEntry entry);
        Task EditJournalEntryAsync(JournalEntry entry);
        Task DeleteJournalEntryAsync(JournalEntry entry);
    }
}
