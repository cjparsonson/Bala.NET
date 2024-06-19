namespace Bala.Shared
{
    public class JournalService
    {
        private readonly JournalDbContext _db;
        public JournalService(JournalDbContext db)
        {
            _db = db;
        }
        public List<JournalEntry> GetJournalEntries()
        {
            return _db.JournalEntries.ToList();
        }
        public void AddJournalEntry(JournalEntry entry)
        {
            _db.JournalEntries.Add(entry);
            _db.SaveChanges();
        }
    }
}
