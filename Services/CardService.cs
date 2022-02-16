using AutoMapper;
using DataAccess;
using DTOs;
using Entities;
using Logic;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class CardService
    {
        private readonly AppDbContext _context;
        private readonly CardLogic _cardLogic;
        private readonly IMapper _mapper;

        public CardService(AppDbContext context, CardLogic cardLogic, IMapper mapper)
        {
            this._context = context;
            this._cardLogic = cardLogic;
            this._mapper = mapper;
        }

        public int Add(CardDto cardDto)
        {
            var card = _mapper.Map<Card>(cardDto);
            _context.Add(card);
            return _context.SaveChanges();
        }

        public CardDto Delete(long cardId)
        {
            Card card = GetCard(cardId);
            _context.Remove(card);
            _context.SaveChanges();
            return _mapper.Map<CardDto>(card);
        }

        public void Delete(CardDto cardDto) => Delete(cardDto.Id);

        //private main get 
        private Card GetCard(long cardId) =>
            _context.Set<Card>().Include(c => c.Images.OrderBy(i => i.Id)).Single(c => c.Id == cardId);

        public CardDto Get(long cardId) => _mapper.Map<CardDto>(GetCard(cardId));


        public int Update(CardDto cardDto)
        {
            var dbCard = GetCard(cardDto.Id);
            dbCard.Answer = cardDto.Answer;
            dbCard.Question = cardDto.Question;
            dbCard.Images.AddRange(cardDto.Images.Select(i => _mapper.Map<CardImage>(i)));

            return _context.SaveChanges();
        }

        public CardDto GetNextCardForReview(long deckId)
        {
            var card = _context.Set<Card>()
                .Include(c => c.Images.OrderBy(i => i.Id))
                .OrderBy(card => card.NextReviewDate)
                .FirstOrDefault(card => card.DeckId == deckId /*&& card.NextReviewDate <= DateTime.Now*/);
            return _mapper.Map<CardDto>(card);
        }

        public CardDto UpdateNextReviewByCorrectAnswer(long cardId, int quality)
        {
            var card = _context.Set<Card>().FirstOrDefault(card => card.Id == cardId);

            if (card != null)
            {
                //card.NextReviewDate = _cardLogic.GetNextReviewDate(card);
                var result = _cardLogic.CalculateKJAlgorithm(card, quality);
                card.NextReviewDate = result.NextReviewDate;
                card.Repetitions = result.Repetitons;
                card.EasinessFactor = result.EasinessFactor;
                card.Interval = result.Interval;

                card.PreviousReviewDate = DateTime.Now;
                _context.SaveChanges();
            }

            return _mapper.Map<CardDto>(card);
        }

        public
            (
            int IDontKnowInterval,
            int HardInterval,
            int GoodInterval,
            int EasyIntervral
            )
            GetAnswerIntervals(CardDto cardDto) => GetAnswerIntervals(cardDto.Id);

        public
            (
            int IDontKnowInterval,
            int HardInterval,
            int GoodInterval,
            int EasyIntervral
            )
            GetAnswerIntervals(long cardId)
        {
            Card card = GetCard(cardId);
            int idontknowInterval = _cardLogic.CalculateKJAlgorithm(card, 0).Interval;
            int hardInterval = _cardLogic.CalculateKJAlgorithm(card, 1).Interval;
            int goodInterval = _cardLogic.CalculateKJAlgorithm(card, 2).Interval;
            int easyIntervarl = _cardLogic.CalculateKJAlgorithm(card, 3).Interval;
            return (idontknowInterval, hardInterval, goodInterval, easyIntervarl);
        }


        public
            (
            string IDontKnowIntervalString,
            string HardIntervalString,
            string GoodIntervalString,
            string EasyIntervralString
            )
           GetAnswerIntervalStrings(CardDto cardDto) => GetAnswerIntervalStrings(cardDto.Id);

        public
            (
            string IDontKnowIntervalString,
            string HardIntervalString,
            string GoodIntervalString,
            string EasyIntervralString
            )
           GetAnswerIntervalStrings(long cardId)
        {
            Card card = GetCard(cardId);

            string ConvertDaysToAppropriateString(int days)
            {
                if (days == 0)
                    return "امروز";

                if (days < 30)
                    return $"{days} {(days <= 1 ? "روز دیگه" : "روز دیگه")}";

                if (days < 360)
                {
                    double numberOfMonths = (double)days / 30;
                    return $"{numberOfMonths:0.00} {((int)numberOfMonths == 1 ? "ماه دیگه" : "ماه دیگه")}";
                }

                double numberOfyears = (double)days / 360;
                return $"{(double)days / 360:0.00} {((int)numberOfyears == 1 ? "سال دیگه" : "سال دیگه")}";
            }

            var intervalsResult = GetAnswerIntervals(card.Id);

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