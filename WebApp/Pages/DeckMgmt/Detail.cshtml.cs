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
        public int NumberOfPages { get; private set; }
        public int CurrentPageNmber { get; private set; }

        public IActionResult OnGet([Bind]int deckId, [Bind]int pageNumber)
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
