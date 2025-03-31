using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bala.Web.Pages
{
    public class IndexModel : PageModel
    {
        public string? DayName { get; set; }
        public void OnGet()
        {
            ViewData["Title"] = "Bala.NET";
            DayName = DateTime.Now.DayOfWeek.ToString();
        }
    }
}
