using AutoMapper;
using DataAccess;
using DTOs;
using Entities;

namespace Services
{
    public class CardImageService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CardImageService(AppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        private CardImage GetCardImage(long id) => _context.Set<CardImage>().Find(id);

        public CardImageDto Get(long id) => _mapper.Map<CardImageDto>(GetCardImage(id));

        public CardImageDto Delete(long imageId)
        {
            CardImage cardImage = GetCardImage(imageId);
            _context.Remove(cardImage);
            _context.SaveChanges();
            return _mapper.Map<CardImageDto>(cardImage);
        }

        public CardImageDto Delete(CardImageDto cardImageDto) => Delete(cardImageDto.Id);
    }
}
