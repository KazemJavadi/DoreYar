namespace DataAccess
{
    public class Question
    {
        public string QuestionText { get; set; }
        public ICollection<string> QuestionImageNames { get; set; }
    }
}
