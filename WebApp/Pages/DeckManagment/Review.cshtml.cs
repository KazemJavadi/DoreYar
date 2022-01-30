using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Helpers;

namespace WebApp.Pages.DeckManagment
{
    public class ReviewModel : PageModel
    {
        public static string AbsolutePath => RazorPageHelper.GetMyAbsolutePath();

        [BindProperty(SupportsGet = true)]
        public long DeckId { get; set; }

        public void OnGet()
        {

        }
    }
}
