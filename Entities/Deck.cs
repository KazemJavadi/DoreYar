using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "You must enter the deck name")]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; } 

        [MaxLength(200)]
        public string DeckHeaderImageName { get; set; }

        //Relationships
        public ICollection<Card> Cards { get; set; }
    }
}
