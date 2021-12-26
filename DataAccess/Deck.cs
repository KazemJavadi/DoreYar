using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class Deck
    {
        public long Id { get; set; }
        public string Name { get; set; }

        //Relationships
        public ICollection<Card> Cards { get; set; }
    }
}
