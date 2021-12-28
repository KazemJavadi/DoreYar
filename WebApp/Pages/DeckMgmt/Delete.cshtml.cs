using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace WebApp.Pages.DeckMgmt
{
    public class DeleteModel : PageModel
    {
        private readonly DeckSerivce deckSerivce;

        public DeleteModel(DeckSerivce deckSerivce)
        {
            this.deckSerivce = deckSerivce;
        }

        public RedirectToPageResult OnGet(int Id)
        {
            if (ModelState.IsValid)
            {
                deckSerivce.Delete(Id);
            }

            return RedirectToPage("All");
        }
    }
}
