using Entities;

namespace Logic
{
    public class CardLogic
    {
        public List<Card> GetTodayReviewCards(ICollection<Card> cards)
        {
            return cards.Where(card => IsForToday(card)).ToList();
        }

        public bool IsForToday(Card card) => card.NextReviewDate <= DateTime.Now;

        public DateTime GetNextReviewDate(Card card)
        {
            int dif = 1;
            if (card.PreviousReviewDate.HasValue) dif = (card.NextReviewDate - card.PreviousReviewDate.Value).Days;
            var nextReviewDate = DateTime.Now.AddDays((dif == 0 ? 1 : dif) * 2);
            return nextReviewDate;
        }
    }
}