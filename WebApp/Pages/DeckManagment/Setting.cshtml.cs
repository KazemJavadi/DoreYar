using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Services.DTOs;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
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
        public InputModel Input { get; set; } = new();

        public bool? IsEdited { get; private set; }

        public void OnGet(int deckId)
        {
            if (ModelState.IsValid)
            {
                Input.Deck = _deckSerivces.Get(deckId);
            }
        }

        public ActionResult OnGetDeckDelete([Required] long deckId)
        {
            if (ModelState.IsValid)
            {
                _deckSerivces.Delete(deckId);
            }

            return RedirectToPage("index");
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Input.DeckHeaderImage != null)
                {
                    Input.Deck.HeaderImageName =
                        _fileHelper.SaveDeckHeader(Input.DeckHeaderImage);
                }

                string userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                _deckSerivces.Update(userId, Input.Deck);

                IsEdited = true;
            }
            else
                IsEdited = false;

            return Page();
        }

        public class InputModel
        {
            public DeckDto Deck { get; set; }
            public IFormFile DeckHeaderImage { get; set; }
        }
    }
}
