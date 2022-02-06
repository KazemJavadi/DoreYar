using DataAccess;
using Entities;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CardService
    {
        private readonly AppDbContext _context;
        private readonly CardLogic _cardLogic;

        public CardService(AppDbContext context, CardLogic cardLogic)
        {
            this._context = context;
            this._cardLogic = cardLogic;
        }

        public int Add(Card card)
        {
            _context.Add(card);
            return _context.SaveChanges();
        }

        public void Delete(int cardId)
        {
            Card card = Get(cardId);
            Delete(card);
        }

        public void Delete(Card card)
        {
            _context.Remove(card);
            _context.SaveChanges();
        }

        public Card Get(long cardId)
        {
            return _context.Set<Card>().Find(cardId);
        }

        public int Edit(Card card)
        {
            _context.Update(card);
            return _context.SaveChanges();
        }

        public Card GetOneOfTodayReviewCards(long deckId)
        {
            var card = _context.Set<Card>()
                .OrderBy(card => card.NextReviewDate)
                .FirstOrDefault(card => card.DeckId == deckId /*&& card.NextReviewDate <= DateTime.Now*/);
            return card;
        }

        public Card UpdateNextReviewForCorrectAnswer(long cardId, int quality)
        {
            var card = _context.Set<Card>()
                .FirstOrDefault(card => card.Id == cardId);
            if (card != null)
            {
                //card.NextReviewDate = _cardLogic.GetNextReviewDate(card);
                var result = _cardLogic.calculateSuperMemo2Algorithm(card, quality);
                card.NextReviewDate = result.NextReviewDate;
                card.Repetitions = result.Repetitons;
                card.EasinessFactor = result.EasinessFactor;
                card.Interval = result.Interval;

                card.PreviousReviewDate = DateTime.Now;
                _context.SaveChanges();
            }

            return card;
        }

        public
            (
            int IDontKnowInterval,
            int HardInterval,
            int GoodInterval,
            int EasyIntervral
            )
            GetAnswerIntervals(Card card)
        {
            int idontknowInterval = _cardLogic.calculateSuperMemo2Algorithm(card, 0).Interval;
            int hardInterval = _cardLogic.calculateSuperMemo2Algorithm(card, 1).Interval;
            int goodInterval = _cardLogic.calculateSuperMemo2Algorithm(card, 2).Interval;
            int easyIntervarl = _cardLogic.calculateSuperMemo2Algorithm(card, 3).Interval;
            return (idontknowInterval, hardInterval, goodInterval, easyIntervarl);
        }

        public
            (
            int IDontKnowInterval,
            int HardInterval,
            int GoodInterval,
            int EasyIntervral
            )
            GetAnswerIntervals(long cardId)
        {
            Card card = Get(cardId);
            return GetAnswerIntervals(card);
        }

        public
            (
            string IDontKnowIntervalString,
            string HardIntervalString,
            string GoodIntervalString,
            string EasyIntervralString
            )
           GetAnswerIntervalStrings(Card card)
        {
            string ConvertDaysToAppropriateString(int days)
            {
                if (days == 0)
                    return "today";

                if (days < 30)
                    return $"{days} {(days <= 1 ? "day" : "days")}";

                if (days < 360)
                {
                    double numberOfMonths = (double)days / 30;
                    return $"{numberOfMonths:0.00} {((int)numberOfMonths == 1 ? "month" : "months")}";
                }

                double numberOfyears = (double)days / 360;
                return $"{(double)days / 360:0.00} {((int)numberOfyears == 1 ? "year" : "years")}";
            }

            var intervalsResult = GetAnswerIntervals(card);

            return
                (
                    ConvertDaysToAppropriateString(intervalsResult.IDontKnowInterval),
                    ConvertDaysToAppropriateString(intervalsResult.HardInterval),
                    ConvertDaysToAppropriateString(intervalsResult.GoodInterval),
                    ConvertDaysToAppropriateString(intervalsResult.EasyIntervral)
                );
        }
    }
}