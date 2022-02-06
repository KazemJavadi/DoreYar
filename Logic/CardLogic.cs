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

        //public DateTime GetNextReviewDate(Card card)
        //{
        //    int dif = 1;
        //    if (card.PreviousReviewDate.HasValue) dif = (card.NextReviewDate - card.PreviousReviewDate.Value).Days;
        //    var nextReviewDate = DateTime.Now.AddDays((dif == 0 ? 1 : dif) * 2);
        //    return nextReviewDate;
        //}

        public 
            (DateTime NextReviewDate, int Repetitons, double Easiness, int Interval) 
            calculateSuperMemo2Algorithm(Card card, int quality)
        {

            if (quality < 0 || quality > 5)
            {
                // throw error here or ensure elsewhere that quality is always within 0-5
            }

            // retrieve the stored values (default values if new cards)
            int repetitions = card.Repetitions;
            double easiness = card.EasinessFactor;
            int interval = card.Interval;

            // easiness factor
            easiness = (double)Math.Max(1.3, easiness + 0.1 - (5.0 - quality) * (0.08 + (5.0 - quality) * 0.02));

            // repetitions
            if (quality < 3)
            {
                repetitions = 0;
            }
            else
            {
                repetitions += 1;
            }

            // interval
            if (repetitions <= 1)
            {
                interval = 1;
            }
            else if (repetitions == 2)
            {
                interval = 6;
            }
            else
            {
                interval = (int)Math.Round(interval * easiness);
            }

            if (interval > 200_000) interval = 200_000;

            return (DateTime.Now.AddDays(interval), repetitions, easiness, interval);

            // next practice 
            //int millisecondsInDay = 60 * 60 * 24 * 1000;
            //long now = System.currentTimeMillis();
            //long nextPracticeDate = now + millisecondsInDay * interval;

            // Store the nextPracticeDate in the database
            // ...
        }
    }
}