using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Services.DTOs;
using System.Security.Claims;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        public static readonly string AbsolutePath = $"/{nameof(IndexModel).Replace("Model", "")}";
        private readonly ILogger<IndexModel> _logger;
        private readonly DeckSerivce _deckSerivce;
        public readonly IConfiguration config;

        public IndexModel(ILogger<IndexModel> logger, DeckSerivce deckSerivce, IConfiguration config)
        {
            _logger = logger;
            this._deckSerivce = deckSerivce;
            this.config = config;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public ICollection<DeckDto> Decks { get; private set; } = new List<DeckDto>();


        public void OnGet()
        {
            string userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!string.IsNullOrEmpty(userId))
            {
                Decks = _deckSerivce.GetAllByUserId(userId);
            }
        }


        public ActionResult OnPost()
        {
            string userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                _deckSerivce.Add(userId, Input.Deck);
            }

            return RedirectToPage("index");
        }


        public class InputModel
        {
            public DeckDto Deck { get; set; }
        }
    }
}