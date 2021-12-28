using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace WebApp.Pages.DeckMgmt
{
    public class AddModel : PageModel
    {
        private readonly DeckSerivce deckSerivce;

        public AddModel(DeckSerivce deckSerivce)
        {
            this.deckSerivce = deckSerivce;
        }

        [BindProperty]
        public Deck Deck { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                deckSerivce.Add(Deck);
            }

            RedirectToPage("All");
        }
    }
}
