using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebApp.Controllers
{
    public class CardController : Controller
    {
        private readonly CardService _cardService;
        private readonly CardImageService _cardImageService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CardController(CardService cardService, CardImageService cardImageService, IWebHostEnvironment webHostEnvironment)
        {
            this._cardService = cardService;
            this._cardImageService = cardImageService;
            this._webHostEnvironment = webHostEnvironment;
        }

        ////Add
        //[HttpPost]
        //public RedirectResult Add(InputModel input)
        //{
        //    if (ModelState.IsValid
        //        && !string.IsNullOrWhiteSpace(input.Card.Question)
        //        && !string.IsNullOrWhiteSpace(input.Card.Answer))
        //    {
        //        input.Card.Images
        //              .AddRange(new FileHelper(_webHostEnvironment)
        //              .SaveCardImages(input.Images).Select(fn => new CardImage() { FileName = fn }));

        //        _cardService.Add(input.Card);
        //    }

        //    return RedirectToReferer();
        //}


        //Delete
        [HttpGet]
        public IActionResult Delete(int cardId)
        {
            if (ModelState.IsValid && cardId > 0)
            {
                _cardService.Delete(cardId);
            }

            if (cardId <= 0)
                return NotFound();

            return RedirectToReferer();
        }


        public IActionResult DeletCardImage(long imageId)
        {
            if (ModelState.IsValid)
            {
                _cardImageService.Delete(imageId);
            }

            return RedirectToReferer();
        }

        private RedirectResult RedirectToReferer() => Redirect(new Uri(Request.Headers["Referer"]).PathAndQuery);



    }
}
