namespace DataAccess
{
    public class Card
    {
        public long Id { get; set; }
        public Question Question { get; set; }
        public Answer Answer { get; set; }
    }
}