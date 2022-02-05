using Logic;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebApp.Controllers
{
    public class ReviewController : Controller
    {
        private readonly CardService _cardService;

        public ReviewController(CardService cardService, CardLogic _cardLogic)
        {
            this._cardService = cardService;
        }

        public RedirectToPageResult Correct(long cardId)
        {
            var card = _cardService.UpdateNextReviewForCorrectAnswer(cardId);
            return RedirectToPage(Pages.DeckManagment.ReviewModel.AbsolutePath, new { card.DeckId });
        }
    }
}
