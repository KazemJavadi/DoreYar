using DataAccess;
using Entities;

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

        public Deck Get(long id)
        {
            return context.Find<Deck>(id);
        }

        public ICollection<Deck> GetAll()
        {
            return context.Decks.ToList();
        }

    }
}