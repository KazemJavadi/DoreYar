using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace WebApp.Pages.DeckMgmt.CardMgmt
{
    public class DeleteModel : PageModel
    {
        public static readonly string Path = $"/{nameof(DeckMgmt)}/{nameof(CardMgmt)}/{nameof(DeleteModel).Replace("Model", "")}";
        private readonly CardService cardService;

        public DeleteModel(CardService cardService)
        {
            this.cardService = cardService;
        }

        public RedirectToPageResult OnGet(int cardId, int deckId, int pageNumber)
        {
            if (ModelState.IsValid)
            {
                cardService.Delete(cardId);
            }

            return RedirectToPage(DeckMgmt.DetailModel.Path, new { deckId, pageNumber });
        }
    }
}
