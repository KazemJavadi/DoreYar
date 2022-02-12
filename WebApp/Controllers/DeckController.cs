using DTOs;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebApp.Controllers
{
    public class DeckController : Controller
    {
        private readonly DeckSerivce _deckSerivce;

        public DeckController(DeckSerivce deckSerivce)
        {
            this._deckSerivce = deckSerivce;
        }

        private const string DefaultRedirectToPageAddress = "/Index";

        //Add
        //[HttpGet]
        //public RedirectToPageResult Add()
        //{
        //    return RedirectToPage(DefaultRedirectToPageAddress);
        //}

        [HttpPost]
        public RedirectToPageResult Add(DeckDto deck)
        {
            if (ModelState.IsValid)
            {
                _deckSerivce.Add(deck);
            }

            return RedirectToPage(DefaultRedirectToPageAddress);
        }

        //Delete
        [HttpGet]
        public RedirectToPageResult Delete(int deckId)
        {
            if (ModelState.IsValid && deckId > 0)
            {
                _deckSerivce.Delete(deckId);
            }

            return RedirectToPage(DefaultRedirectToPageAddress);
        }
    }
}
