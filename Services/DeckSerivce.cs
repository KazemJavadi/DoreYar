using AutoMapper;
using DataAccess;
using DTOs;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class DeckSerivce
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public DeckSerivce(AppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public int Add(DeckDto deckDto)
        {
            var deck = _mapper.Map<Deck>(deckDto);
            _context.Add(deck);
            return _context.SaveChanges();
        }

        public DeckDto Delete(DeckDto deckDto) => Delete(deckDto.Id);

        public DeckDto Delete(long deckId)
        {
            Deck deck = GetDeck(deckId);
            _context.Remove(deck);
            _context.SaveChanges();
            return _mapper.Map<DeckDto>(deck);
        }

        private Deck GetDeck(long deckId, bool loadCards = false, DeckCardsOptions options = null)
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

        public DeckDto Get(long deckId, bool loadCards = false, DeckCardsOptions options = null) =>
            _mapper.Map<DeckDto>(GetDeck(deckId, loadCards, options));


        public ICollection<DeckDto> GetAll() =>
            _mapper.Map<ICollection<DeckDto>>(_context.Decks.ToList());

        public void Update(DeckDto deckDto)
        {
            var deck = _mapper.Map<Deck>(deckDto);
            _context.Update(deck);
            _context.SaveChanges();
        }
    }
}