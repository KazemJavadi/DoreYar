using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CardService
    {
        private readonly AppDbContext context;

        public CardService(AppDbContext context)
        {
            this.context = context;
        }
        
        public int Add(Card card)
        {
            context.Add(card);
            return context.SaveChanges();
        }

        public void Delete(int cardId)
        {
            Card card = Get(cardId);
            Delete(card);
        }

        public void Delete(Card card)
        {
            context.Remove(card);
            context.SaveChanges();
        }

        public Card Get(long cardId)
        {
            return context.Set<Card>().Find(cardId);
        }

        public int Edit(Card card)
        {
            context.Update(card);
            return context.SaveChanges();
        }
    }
}
