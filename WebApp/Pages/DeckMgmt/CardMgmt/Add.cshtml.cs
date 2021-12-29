using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace WebApp.Pages.DeckMgmt.CardMgmt
{
    public class AddModel : PageModel
    {
        public static readonly string Path = $"/{nameof(DeckMgmt)}/{nameof(CardMgmt)}/{nameof(AddModel).Replace("Model","")}";
        private readonly CardService cardService;

        public AddModel(CardService cardService)
        {
            this.cardService = cardService;
        }

        public RedirectToPageResult OnPost(Card card)
        {
            if(ModelState.IsValid
                && !string.IsNullOrWhiteSpace(card.Question)
                && !string.IsNullOrWhiteSpace(card.Answer))
            {
                cardService.Add(card);
            }

            return RedirectToPage(DeckMgmt.DetailModel.Path, new { card.DeckId, pageNumber = 1});
        }
    }
}
