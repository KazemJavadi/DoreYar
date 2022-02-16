using DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        public static readonly string AbsolutePath = $"/{nameof(IndexModel).Replace("Model", "")}";
        private readonly ILogger<IndexModel> _logger;
        private readonly DeckSerivce _deckSerivce;

        public IndexModel(ILogger<IndexModel> logger, DeckSerivce deckSerivce)
        {
            _logger = logger;
            this._deckSerivce = deckSerivce;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public ICollection<DeckDto> Decks { get; private set; }


        public void OnGet()
        {
            Decks = _deckSerivce.GetAll();
        }


        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _deckSerivce.Add(Input.Deck);
            }

            return RedirectToPage("index");
        }


        public class InputModel
        {
            public DeckDto Deck { get; set; }
        }
    }
}