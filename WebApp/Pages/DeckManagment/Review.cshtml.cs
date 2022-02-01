using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using WebApp.Helpers;

namespace WebApp.Pages.DeckManagment
{
    public class ReviewModel : PageModel
    {
        public static string AbsolutePath => RazorPageHelper.GetMyAbsolutePath();

        public ReviewModel(CardService cardService, CardLogic cardLogic)
        {

        }

        [BindProperty(SupportsGet = true)]
        public long DeckId { get; set; }

        public void OnGet()
        {

        }
    }
}
