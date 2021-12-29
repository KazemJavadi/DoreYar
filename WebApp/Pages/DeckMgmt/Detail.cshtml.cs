using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace WebApp.Pages.DeckMgmt
{
    public class DetailModel : PageModel
    {
        public static readonly string Path = $"/{nameof(DeckMgmt)}/{nameof(DetailModel).Replace("Model", string.Empty)}";
        private readonly DeckSerivce deckSerivce;

        public DetailModel(DeckSerivce deckSerivce)
        {
            this.deckSerivce = deckSerivce;
        }

        public Deck Deck { get; set; }
        public int NumberOfPages { get; set; }

        public void OnGet(int deckId, int pageNumber)
        {
            if (ModelState.IsValid)
            {
                DeckCardsOptions options = new() {PageSize = 5, PageNumber = pageNumber - 1 };
                Deck = deckSerivce.Get(deckId, true, options);
                NumberOfPages = options.NumberOfPages;
            }
        }
    }
}
