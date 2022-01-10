using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebApp.Controllers
{
    public class DeckController : Controller
    {
        private readonly DeckSerivce deckSerivce;

        public DeckController(DeckSerivce deckSerivce)
        {
            this.deckSerivce = deckSerivce;
        }

        private const string DefaultRedirectToPageAddress = "/Index";
        
        //Add
        //[HttpGet]
        //public RedirectToPageResult Add()
        //{
        //    return RedirectToPage(DefaultRedirectToPageAddress);
        //}

        [HttpPost]
        public RedirectToPageResult Add(Deck deck)
        {
            if (ModelState.IsValid)
            {
                deckSerivce.Add(deck);
            }

            return RedirectToPage(DefaultRedirectToPageAddress);
        }

        //Delete
        [HttpGet]
        public RedirectToPageResult Delete(int deckId)
        {
            if (ModelState.IsValid && deckId > 0)
            {
                deckSerivce.Delete(deckId);
            }

            return RedirectToPage(DefaultRedirectToPageAddress);
        }
    }
}
