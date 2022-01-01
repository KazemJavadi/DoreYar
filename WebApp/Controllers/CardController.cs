using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebApp.Controllers
{
    public class CardController : Controller
    {
        private readonly CardService cardService;

        public CardController(CardService cardService)
        {
            this.cardService = cardService;
        }

        //Add
        [HttpPost]
         public RedirectResult Add(Card card)
        {
            if(ModelState.IsValid
                && !string.IsNullOrWhiteSpace(card.Question)
                && !string.IsNullOrWhiteSpace(card.Answer))
            {
                cardService.Add(card);
            }

            return RedirectToReferer();
        }


        //Delete
        [HttpGet]
        public IActionResult Delete(int cardId)
        {
            if (ModelState.IsValid && cardId > 0)
            {
                cardService.Delete(cardId);
            }

            if (cardId <= 0)
                return NotFound();

            return RedirectToReferer();
        }

        private RedirectResult RedirectToReferer() => Redirect(new Uri(Request.Headers["Referer"]).PathAndQuery);
    }
}
