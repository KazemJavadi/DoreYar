using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CardImageService
    {
        private readonly AppDbContext _context;

        public CardImageService(AppDbContext context)
        {
            this._context = context;
        }

        public CardImage Get(long id)
        {
            return _context.Set<CardImage>().Find(id);
        }

        public CardImage Delete(long imageId)
        {
            CardImage cardImage = Get(imageId);
            return Delete(cardImage);   
        }


        public CardImage Delete(CardImage cardImage)
        {
            _context.Remove(cardImage);
            _context.SaveChanges();
            return cardImage;   
        }
    }
}
