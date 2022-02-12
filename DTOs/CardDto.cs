namespace DTOs
{
    public class CardDto
    {
        public long Id { get; set; }
        public long DeckId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        public List<CardImageDto> Images { get; set; } = new();

    }
}