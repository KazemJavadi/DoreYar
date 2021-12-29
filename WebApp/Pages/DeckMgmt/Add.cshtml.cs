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

        private const string DefaultRedirectToPageAddress = "/Index";

        public RedirectToPageResult OnGet()
        {
            return RedirectToPage(DefaultRedirectToPageAddress);
        }

        public RedirectToPageResult OnPost()
        {
            if (ModelState.IsValid && !string.IsNullOrWhiteSpace(Deck.Name))
            {
                deckSerivce.Add(Deck);
            }

            return RedirectToPage(DefaultRedirectToPageAddress);
        }
    }
}
