using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace WebApp.Pages.DeckMgmt.CardMgmt
{
    public class EditModel : PageModel
    {
        public static readonly string Path = $"/{nameof(DeckMgmt)}/{nameof(CardMgmt)}/{nameof(EditModel).Replace("Model", "")}";
        private readonly CardService cardService;

        public EditModel(CardService cardService)
        {
            this.cardService = cardService;
        }

        [BindProperty]
        public Card Card { get; set; }
        public int PageNumber { get; set; }

        public bool? IsEdited { get; set; }

        public void OnGet(long cardId, int pageNumber)
        {
            if (ModelState.IsValid)
            {
                string referer = Request.Headers["Referer"].ToString();
                Card = cardService.Get(cardId);
                PageNumber = pageNumber;
            }
        }

        public void OnPost(int pageNumber)
        {
            if (ModelState.IsValid)
            {
                string referer = Request.Headers["Referer"].ToString();
                cardService.Edit(Card);
                IsEdited = true;
                PageNumber = pageNumber;
            }
            else
                IsEdited = false;
        }
    }
}
