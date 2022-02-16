using DTOs;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebApp.Controllers
{
    [ApiController]
    public class CardController : BaseController
    {
        private readonly CardService _cardService;

        public CardController(CardService cardService)
        {
            this._cardService = cardService;
        }

        //[HttpGet("get/[action]/{deckId}")]
        //public IEnumerable<CardDto> All(long deckId)
        //{
        //    return _cardService.(deckId);
        //}
    }
}
