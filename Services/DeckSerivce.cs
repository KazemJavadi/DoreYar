using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class DeckSerivce
    {
        private readonly AppDbContext context;

        public DeckSerivce(AppDbContext context)
        {
            this.context = context;
        }

        public int Add(Deck deck)
        {
            context.Add(deck);
            return context.SaveChanges();
        }

        public int Delete(Deck deck)
        {
            context.Remove(deck);
            return context.SaveChanges();
        }

        public int Delete(int deckId)
        {
            Deck deck = Get(deckId);
            return Delete(deck);
        }

        public Deck Get(long deckId, bool loadCards = false, DeckCardsOptions options = null)
        {

            if (loadCards)
            {
                int total = context.Set<Card>().Where(c => c.DeckId == deckId).Count();
                options.NumberOfPages = (total / options.PageSize) + (total % options.PageSize == 0 ? 0 : 1);


                return context.Decks.Include(deck =>
                   deck.Cards
                   .Skip(options.PageNumber * options.PageSize)
                   .Take(options.PageSize)
                    ).Single(d => d.Id == deckId);
            }
            else
                return context.Find<Deck>(deckId);
        }

        public ICollection<Deck> GetAll()
        {
            return context.Decks.ToList();
        }
    }
}