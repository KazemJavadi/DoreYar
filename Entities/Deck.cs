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
        [MaxLength(500)]    
        [StringLength(200)]
        public string Name { get; set; }

        [MaxLength(1000)]
        [StringLength(1000)]
        public string Description { get; set; } 

        [MaxLength(200)]
        public string DeckHeaderImageName { get; set; }

        //Relationships
        public ICollection<Card> Cards { get; set; }
    }
}
