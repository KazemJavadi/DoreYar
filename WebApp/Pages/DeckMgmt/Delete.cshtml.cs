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

        private const string DefaultRedirectToPageAddress = "/Index";

        public RedirectToPageResult OnGet(int Id)
        {
            if (ModelState.IsValid)
            {
                deckSerivce.Delete(Id);
            }

            return RedirectToPage(DefaultRedirectToPageAddress);
        }
    }
}
