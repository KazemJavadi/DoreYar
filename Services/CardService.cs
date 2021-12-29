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
    }
}
