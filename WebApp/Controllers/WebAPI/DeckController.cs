using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebApp.Controllers.WebAPI
{
    [ApiController]
    [Route("/API/[Controller]")]
    public class DeckController : ControllerBase
    {
        private readonly DeckSerivce _deckService;

        public DeckController(DeckSerivce deckService)
        {
            this._deckService = deckService;
        }

        [HttpGet("[Action]")]
        public ICollection<Deck> All()
        {
            return _deckService.GetAll();
        }


    }
}
