using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bala.DataContext.Sqlite;
using Bala.EntityModels.Sqlite;

namespace Bala.Web.Pages
{
    public class EntriesModel : PageModel
    {
        private readonly JournalDbContext _db;
        public EntriesModel(JournalDbContext db)
        {
            _db = db;
        }
        public IEnumerable<JournalEntry>? Entries { get; set; }
        public void OnGet()
        {
            ViewData["Title"] = "Journal Entries";
            Entries = _db.JournalEntries
                .OrderByDescending(e => e.Date)
                .ToList();
        }
    }
}
