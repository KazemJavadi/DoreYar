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
    }
}