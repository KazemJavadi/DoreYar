using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace WebApp.Pages.DeckMgmt
{
    public class AllModel : PageModel
    {
        private readonly DeckSerivce deckSerivce;

        public AllModel(DeckSerivce deckSerivce)
        {
            this.deckSerivce = deckSerivce;
        }

        public ICollection<Deck> Decks { get; private set; }

        public void OnGet()
        {
            Decks = deckSerivce.GetAll();
        }
    }
}
