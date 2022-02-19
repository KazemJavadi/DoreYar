using DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using System.ComponentModel.DataAnnotations;
using WebApp.Helpers;

namespace WebApp.Pages.DeckManagment
{
    public class DetailModel : PageModel
    {
        public static string AbsolutePath => RazorPageHelper.GetMyAbsolutePath();

        private readonly DeckSerivce _deckSerivce;
        private readonly CardService _cardService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DetailModel(DeckSerivce deckSerivce, CardService cardService, IWebHostEnvironment webHostEnvironment)
        {
            this._deckSerivce = deckSerivce;
            this._cardService = cardService;
            this._webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public InputModel Input { get; set; }


        public DeckDto CurrentDeck { get; set; }
        public int NumberOfPages { get; private set; }
        public long CurrentPageNmber { get; private set; }

        public ActionResult OnGet(
            [Required, Range(1, long.MaxValue)] long? deckId,
            [Required, Range(1, long.MaxValue)] int? pageNumber
            )
        {
            if (ModelState.IsValid)
            {
                LoadCurrentDeck(deckId.Value, pageNumber.Value);
                return Page();
            }

            return RedirectToPage("index");
        }

        public ActionResult OnGetCardDelete(
            [Required, Range(1, long.MaxValue)] long? cardId,
            [Required, Range(1, long.MaxValue)] long? deckId,
            [Required, Range(1, long.MaxValue)] int? pageNumber)
        {
            if (ModelState.IsValid)
            {
                _cardService.Delete(cardId.Value);

                LoadCurrentDeck(deckId.Value, pageNumber.Value);
                CurrentPageNmber = pageNumber.Value;
                return Page();
            }

            return RedirectToPage("index");
        }

        public ActionResult OnPost(
            [Required, Range(1, long.MaxValue)] long? deckId,
            [Required, Range(1, int.MaxValue)] int? pageNumber
            )
        {
            if (ModelState.IsValid)
            {
                Input.Card.Images
                      .AddRange(new FileHelper(_webHostEnvironment)
                      .SaveCardImages(Input.Images).Select(fn => new CardImageDto() { FileName = fn }));

                _cardService.Add(Input.Card);

                return RedirectToPage(new { deckId, pageNumber });
            }

            return RedirectToPage("index");
        }

        private DeckCardsOptions GetDeckCardsOptions(int pageNumber) => new() { PageSize = 10, PageNumber = pageNumber };

        private void LoadCurrentDeck(long deckId, int currentPageNumber)
        {
            var options = GetDeckCardsOptions(currentPageNumber);
            CurrentDeck = _deckSerivce.Get(deckId, true, options, out int numberOfPages);
            NumberOfPages = numberOfPages;
            CurrentPageNmber = options.PageNumber;
        }

        public class InputModel
        {
            public CardDto Card { get; set; }
            public IFormFile[] Images { get; set; }
        }
    }
}
