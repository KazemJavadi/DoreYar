using Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        public static readonly string Path = $"/{nameof(IndexModel).Replace("Model", "")}";
        private readonly ILogger<IndexModel> _logger;
        private readonly DeckSerivce deckSerivce;

        public IndexModel(ILogger<IndexModel> logger, DeckSerivce deckSerivce)
        {
            _logger = logger;
            this.deckSerivce = deckSerivce;
        }

        public ICollection<Deck> Decks { get; private set; }


        public void OnGet()
        {
            Decks = deckSerivce.GetAll();
        }

    }
}