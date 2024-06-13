namespace Bala.Shared
{
    public static class JournalEntryValidationExtensions
    {
        public static bool IsValidDate(this JournalEntry entry)
        {
            return entry.Date <= DateTime.Now;
        }
    }
}
