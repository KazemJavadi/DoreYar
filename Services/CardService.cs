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
                .OrderBy(card => card.RegDate)
                .OrderBy(card=>card.Id)
                .FirstOrDefault(card => card.DeckId == deckId && card.NextReviewDate <= DateTime.Now);
            return card;
        }

        public Card UpdateNextReviewForCorrectAnswer(long cardId)
        {
            var card  = _context.Set<Card>()
                .FirstOrDefault(card => card.Id == cardId);
            if(card != null)
            {
                card.NextReviewDate = _cardLogic.GetNextReviewDate(card);
                card.PreviousReviewDate = DateTime.Now;
                _context.SaveChanges();
            }

            return card;
        }
    }
}
