using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTOs;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Controllers
{
    [ApiController]
    public class DeckController : BaseController
    {
        private readonly DeckSerivce _deckService;

        public DeckController(DeckSerivce deckService)
        {
            this._deckService = deckService;
        }

        [HttpGet("get/[action]")]
        public ICollection<DeckDto> All()
        {
            return _deckService.GetAll();
        }

        [HttpGet("[action]/{deckId}")]
        public ActionResult<DeckDto> Get([Required] int deckId)
        {
            var deck = _deckService.Get(deckId);

            if (deck == null)
                return NotFound();

            return deck;
        }

        [HttpPost("[action]")]
        public ActionResult Add(DeckDto deck)
        {

            if (_deckService.Add("", deck) == 1)
                return Ok();
            else
                return StatusCode(500);
        }

        [HttpDelete("[action]/{deckId}")]
        public ActionResult Delete([Required] long deckId)
        {
            //return StatusCode(204, _deckService.Delete(deckId));
            return Ok(_deckService.Delete(deckId));
        }

    }
}
