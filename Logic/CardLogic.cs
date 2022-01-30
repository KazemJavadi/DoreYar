using Entities;

namespace Logic
{
    public class CardLogic
    {
        private readonly ICardsService _cardService;
        private readonly int _deckId;

        public CardLogic(ICardsService cardsService, int deckId)
        {
            this._cardService = cardsService;
            this._deckId = deckId;
        }

        public List<Card> GetTodayReviewCards()
        {
            var cards = _cardService.GetAll(_deckId);
            return cards.Where(card => IsForToday(card)).ToList();
        }

        private bool IsForToday(Card card) => card.NextReviewDate <= DateTime.Now;

        public DateTime GetNextReviewDate(Card card)
        {
            int dif = (card.NextReviewDate - card.PreviousReviewDate).Days;
            var nextReviewDate  = card.NextReviewDate.AddDays(dif * 2);
            return nextReviewDate;
        }
    }
}