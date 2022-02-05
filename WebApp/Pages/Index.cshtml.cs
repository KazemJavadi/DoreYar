using Entities;
using Microsoft.AspNetCore.Mvc;
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
           

            string realFilePath = Url.Page("/DeckManagment/Detail", new { DeckId = 2, PaqeNmber = 1 });
            string physicalPath =
                $"/{realFilePath.Remove(0, realFilePath.IndexOf("Pages") + 1 + "Pages".Length).Replace('.', '/').Replace("Model", string.Empty)}";
            Decks = deckSerivce.GetAll();
        }

    }
}