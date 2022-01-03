using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using WebApp.Helpers;

namespace WebApp.Pages.DeckManagment
{
    public class DetailModel : PageModel
    {
        public static string AbsolutePath => RazorPageHelper.GetMyAbsolutePath();

        private readonly DeckSerivce deckSerivce;

        public DetailModel(DeckSerivce deckSerivce)
        {
            this.deckSerivce = deckSerivce;
        }


        public Deck Deck { get; set; }
        public int NumberOfPages { get; private set; }
        public int CurrentPageNmber { get; private set; }

        public IActionResult OnGet(int deckId, int pageNumber)
        {

            if (ModelState.IsValid && deckId > 0)
            {
                DeckCardsOptions options = new() { PageSize = 5, PageNumber = pageNumber };
                Deck = deckSerivce.Get(deckId, true, options);
                NumberOfPages = options.NumberOfPages;
                CurrentPageNmber = options.PageNumber;
                return Page();
            }
            
            return RedirectToPage(Pages.IndexModel.Path);
        }
    }
}
