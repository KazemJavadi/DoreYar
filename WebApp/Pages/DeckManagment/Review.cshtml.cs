using Entities;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using WebApp.Helpers;

namespace WebApp.Pages.DeckManagment
{
    public class ReviewModel : PageModel
    {
        private readonly CardService cardService;

        public static string AbsolutePath => RazorPageHelper.GetMyAbsolutePath();

        public ReviewModel(CardService cardService)
        {
            this.cardService = cardService;
        }

        [BindProperty(SupportsGet = true)]
        public long DeckId { get; set; }

        public Card ReviewCard { get; set; }

        public void OnGet()
        {
            ReviewCard = cardService.GetOneOfTodayReviewCards(DeckId);
        }
    }
}
