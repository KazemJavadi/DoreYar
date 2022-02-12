namespace DTOs
{
    public class DeckDto
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string DeckHeaderImageName { get; set; }

        //Relationships
        public ICollection<CardDto> Cards { get; set; }
    }
}
