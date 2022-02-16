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
        [BindProperty(SupportsGet = true)]
        public long DeckId { get; set; }
        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; }


        public DeckDto Deck { get; set; }
        public int NumberOfPages { get; private set; }
        public int CurrentPageNmber { get; private set; }

        public IActionResult OnGet()
        {
            if (ModelState.IsValid && DeckId > 0)
            {
                LoadDeck();
                return Page();
            }

            return RedirectToPage(Pages.IndexModel.AbsolutePath);
        }

        public void OnGetCardDelete([Required]long cardId, [Required] long deckId, [Required] int pageNumber)
        {
            if (ModelState.IsValid)
            {
                _cardService.Delete(cardId);
            }

            CurrentPageNmber = pageNumber;
            DeckId = deckId;
            LoadDeck();
        }

        public void OnPost()
        {
            if (ModelState.IsValid
              && !string.IsNullOrWhiteSpace(Input.Card.Question)
              && !string.IsNullOrWhiteSpace(Input.Card.Answer))
            {
                Input.Card.Images
                      .AddRange(new FileHelper(_webHostEnvironment)
                      .SaveCardImages(Input.Images).Select(fn => new CardImageDto() { FileName = fn }));

                _cardService.Add(Input.Card);
            }

            LoadDeck();
        }

        private DeckCardsOptions GetDeckCardsOptions(int pageNumber) => new() { PageSize = 5, PageNumber = pageNumber };
        private void LoadDeck()
        {
            var options = GetDeckCardsOptions(PageNumber);
            Deck = _deckSerivce.Get(DeckId, true, options);
            NumberOfPages = options.NumberOfPages;
            CurrentPageNmber = options.PageNumber;
        }

        public class InputModel
        {
            public CardDto Card { get; set; }
            public IFormFile[] Images { get; set; }
        }
    }
}
