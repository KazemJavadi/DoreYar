using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using WebApp.Helpers;

namespace WebApp.Pages.DeckManagment
{
    public class EditModel : PageModel
    {
        private readonly DeckSerivce _deckSerivces;

        public static string AbsolutePath => RazorPageHelper.GetMyAbsolutePath();

        public EditModel(DeckSerivce deckSerivces)
        {
            this._deckSerivces = deckSerivces;
        }

        [BindProperty]
        public Deck Deck { get; set; }

        [BindProperty]
        public IFormFile DeckHeaderImage { get; set; }

        public void OnGet(int deckId)
        {
            if (ModelState.IsValid)
            {
                Deck = _deckSerivces.Get(deckId);
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = 
                    $"deck-header-{Deck.Id}{TimeHelper.GetTimeStampNow()}{Path.GetExtension(DeckHeaderImage.FileName)}";
            }

            return Page();
        }
    }
}
