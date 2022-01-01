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
        //public int PageNumber { get; set; }


        public string MainReferer { get; set; }

        public bool? IsEdited { get; set; }


        public void OnGet(long cardId)
        {
            if (ModelState.IsValid)
            {
                Card = cardService.Get(cardId);
                MainReferer = Request.Headers["Referer"].ToString();
            }
        }

        public void OnPost(string mainReferer)
        {
            if (ModelState.IsValid)
            {
                cardService.Edit(Card);

                IsEdited = true;
                MainReferer = mainReferer;
            }
            else
                IsEdited = false;
        }
    }
}
