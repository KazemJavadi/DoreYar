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

        //public 
        //    (DateTime NextReviewDate, int Repetitons, double Easiness, int Interval) 
        //    calculateSuperMemo2Algorithm(Card card, int quality)
        //{

        //    if (quality < 0 || quality > 5)
        //    {
        //        // throw error here or ensure elsewhere that quality is always within 0-5
        //    }

        //    // retrieve the stored values (default values if new cards)
        //    int repetitions = card.Repetitions;
        //    double easiness = card.EasinessFactor;
        //    int interval = card.Interval;

        //    // easiness factor
        //    easiness = (double)Math.Max(1.3, easiness + 0.1 - (5.0 - quality) * (0.08 + (5.0 - quality) * 0.02));

        //    // repetitions
        //    if (quality < 3)
        //    {
        //        repetitions = 0;
        //    }
        //    else
        //    {
        //        repetitions += 1;
        //    }

        //    // interval
        //    if (repetitions <= 1)
        //    {
        //        interval = 1;
        //    }
        //    else if (repetitions == 2)
        //    {
        //        interval = 6;
        //    }
        //    else
        //    {
        //        interval = (int)Math.Round(interval * easiness);
        //    }

        //    if (interval > 200_000) interval = 200_000;

        //    return (DateTime.Now.AddDays(interval), repetitions, easiness, interval);

        //    // next practice 
        //    //int millisecondsInDay = 60 * 60 * 24 * 1000;
        //    //long now = System.currentTimeMillis();
        //    //long nextPracticeDate = now + millisecondsInDay * interval;

        //    // Store the nextPracticeDate in the database
        //    // ...
        //}

        //public
        //    (DateTime NextReviewDate, int Repetitons, decimal Easiness, int Interval)
        //    calculateSuperMemo2Algorithm(Card card, int quality)
        //{
        //    if (quality > 3) quality = 3;
        //    if (quality < 0) quality = 0;

        //    // retrieve the stored values (default values if new cards)
        //    int repetitions = card.Repetitions;
        //    decimal easiness = card.EasinessFactor;
        //    int interval = card.Interval;

        //    // easiness factor
        //    decimal dif = 0.1M;
        //    easiness = quality switch
        //    {
        //        0 => 1.3M,
        //        1 => easiness - dif > 1.3M ? easiness - dif : 1.3M,
        //        2 => easiness,
        //        3 => easiness + dif < 2.5M ? easiness + dif : 2.5M,
        //        _ => throw new NotImplementedException()
        //    };

        //    //if (quality == 0)
        //    //    easiness = 1.3;
        //    //else
        //    //    easiness = (double)Math.Max(1.3, easiness + 0.1 - (3 - quality) * (0.08 + (3 - quality) * 0.02));

        //    // repetitions
        //    repetitions = quality < 1 ? 0 : repetitions + 1;

        //    // interval
        //    if (repetitions == 0)
        //    {
        //        interval = 0;
        //    }
        //    else if (repetitions == 1)
        //    {
        //        interval = 1;
        //    }
        //    else if (repetitions == 2)
        //    {
        //        interval = 6;
        //    }
        //    else
        //    {
        //        interval = (int)Math.Round(interval * easiness);
        //    }


        //    if (interval > 200_000) interval = 200_000;

        //    return (DateTime.Now.AddDays(interval), repetitions, easiness, interval);
        //}

        //public
        //    (DateTime NextReviewDate, long Repetitons, decimal EasinessFactor, int Interval)
        //    calculateSuperMemo2Algorithm(Card card, int quality)
        //{
        //    if (quality > 3) quality = 3;
        //    if (quality < 0) quality = 0;

        //    // retrieve the stored values (default values if new cards)
        //    int q = quality + 1;
        //    long r = card.Repetitions;
        //    decimal ef = card.EasinessFactor;
        //    int i = card.Interval;

        //    ef = ((ef) + (q / 4.0M)) /2;

        //    if (q == 1)
        //    {
        //        i = 0;
        //    }
        //    else
        //    {
        //        if (i == 0) i = 1;
        //        i = (int)Math.Ceiling((i + (i * ef)) * (q / 4.0M) * 1.3M);
        //    }
        //    return (DateTime.Now.AddDays(i), r + 1, ef, i);
        //}

        public
            (DateTime NextReviewDate, long Repetitons, decimal EasinessFactor, int Interval)
            calculateSuperMemo2Algorithm(Card card, int quality)
        {
            if (quality > 3) quality = 3;
            if (quality < 0) quality = 0;

            // retrieve the stored values (default values if new cards)
            int q = quality;
            long r = card.Repetitions;
            decimal ef = card.EasinessFactor;
            int i = card.Interval;
            decimal eff = 0;
            int ceff = 2;
            int cef = 1;

            ef = ((ef * r) + ((q + 1) / 4.0M)) / (r + 1);
            eff = ((ef) + ((q + 1) / 4.0M)) / 2;
            ef = (ef * cef + eff * ceff) / (cef + ceff);

            if (i == 0) i = 1;

            if (q == 0)
            {
                i = 0;
            }
            else if (q == 1)
            {
                i = (int)Math.Max(1M, Math.Round(i * q * ef));
            }
            else if (q == 2)
            {
                i = (int)Math.Max(2M, Math.Round(i * q * ef));
            }
            else
            {
                i = (int)Math.Max(3M, Math.Round(i * q * ef));
            }

            if (i > 200_000) i = 200_000;

            return (DateTime.Now.AddDays(i), r + 1, ef, i);
        }
    }
}