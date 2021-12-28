namespace Entities
{
    public class Card
    {
        public long Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public DateTime NextReviewDate { get; set; }
    }
}