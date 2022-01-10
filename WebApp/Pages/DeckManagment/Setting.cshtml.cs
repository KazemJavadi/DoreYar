using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using WebApp.Helpers;

namespace WebApp.Pages.DeckManagment
{
    public class SettingModel : PageModel
    {
        private readonly DeckSerivce _deckSerivces;
        private readonly FileHelper _fileHelper;

        public static string AbsolutePath => RazorPageHelper.GetMyAbsolutePath();

        public SettingModel(DeckSerivce deckSerivces, FileHelper fileHelper)
        {
            this._deckSerivces = deckSerivces;
            this._fileHelper = fileHelper;
        }

        [BindProperty]
        public Deck Deck { get; set; }

        [BindProperty]
        public IFormFile DeckHeaderImage { get; set; }

        public bool? IsEdited { get; private set; }

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
                if (DeckHeaderImage != null)
                {
                    Deck.DeckHeaderImageName =
                        _fileHelper.SaveDeckHeader(DeckHeaderImage);
                }

                _deckSerivces.Update(Deck);
                IsEdited = true;
            }
            else
                IsEdited = false;

            return Page();
        }
    }
}
