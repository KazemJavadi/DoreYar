namespace Entities
{
    public class Card
    {
        public long Id { get; set; }
        public long DeckId { get; set; }

        public string Question { get; set; }
        public string Answer { get; set; }
        public DateTime NextReviewDate { get; set; }
    }
}