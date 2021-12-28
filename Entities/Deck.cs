using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table(nameof(Deck))]
    public class Deck
    {
        public long Id { get; set; }
        public string Name { get; set; }

        //Relationships
        public ICollection<Card> Cards { get; set; }
    }
}
