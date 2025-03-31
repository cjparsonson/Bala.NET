using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bala.DataContext.Sqlite;
using Bala.EntityModels.Sqlite;
using Microsoft.AspNetCore.Components;

namespace Bala.Web.Pages
{
    public class EditEntryModel : PageModel
    {
        private readonly JournalDbContext _db;
        public EditEntryModel(JournalDbContext db)
        {
            _db = db;
        }
        public JournalEntry? Entry { get; set; }
        public void OnGet()
        {
            ViewData["Title"] = "Edit Journal Entry";
            Entry = _db.JournalEntries.Find(id);


        }
    }
}
