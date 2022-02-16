using DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using System.ComponentModel.DataAnnotations;
using WebApp.Helpers;

namespace WebApp.Pages.DeckManagment
{
    public class ReviewModel : PageModel
    {
        private readonly CardService _cardService;

        public static string AbsolutePath => RazorPageHelper.GetMyAbsolutePath();

        public ReviewModel(CardService cardService)
        {
            this._cardService = cardService;
        }

        public CardDto ReviewCard { get; set; }

        public (string IDontKnow, string Hard, string Good, string Easy) IntervalStrings { get; set; }


        public ActionResult OnGet([Required] long deckId, long? cardId, int? quality)
        {
            if (ModelState.IsValid)
            {
                ProcessAnswerToQuestion(cardId, quality);

                ReviewCard = _cardService.GetNextCardForReview(deckId);

                SetPageModelIntervalStrings(ReviewCard);

                return Page();
            }

            return RedirectToPage("index");
        }

        public void ProcessAnswerToQuestion(long? cardId, int? quality)
        {
            if (cardId is > 0 && quality is >= 0)
                _cardService.UpdateNextReviewByCorrectAnswer(cardId.Value, quality.Value);
        }

        public void SetPageModelIntervalStrings(CardDto cardDto)
        {
            if (ReviewCard != null)
                IntervalStrings = _cardService.GetAnswerIntervalStrings(cardDto);
        }
    }
}
