using DataAccess;
using Entities;
using Logic;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class DeckSerivce
    {
        private readonly AppDbContext _context;

        public DeckSerivce(AppDbContext context)
        {
            this._context = context;
        }

        public int Add(Deck deck)
        {
            _context.Add(deck);
            return _context.SaveChanges();
        }

        public int Delete(Deck deck)
        {
            _context.Remove(deck);
            return _context.SaveChanges();
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
                int total = _context.Set<Card>().Where(c => c.DeckId == deckId).Count();
                options.NumberOfPages = (total / options.PageSize) + (total % options.PageSize == 0 ? 0 : 1);

                if (options.PageNumber > options.NumberOfPages)
                    options.PageNumber = options.NumberOfPages;
                else if (options.PageNumber <= 0)
                    options.PageNumber = 1;

                return _context.Decks.Include(deck =>
                   deck.Cards
                   .Skip((options.PageNumber - 1) * options.PageSize)
                   .Take(options.PageSize)
                    ).Single(d => d.Id == deckId);
            }
            else
                return _context.Find<Deck>(deckId);
        }

        public ICollection<Deck> GetAll()
        {
            return _context.Decks.ToList();
        }

        public void Update(Deck deck)
        {
            _context.Update(deck);
            _context.SaveChanges();
        }
    }
}