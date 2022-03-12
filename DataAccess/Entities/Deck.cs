using DataAccess.Entities.DbStrLenInfo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    [Table(nameof(Deck))]
    public class Deck
    {
        public long Id { get; set; }

        [Required]
        //[MaxLength(DbStrMaxLen.UserUserIdLen)]
        public string UserId { get; set; }

        [Required]
        [MaxLength(DbStrMaxLen.DeckNameLen)]
        public string Name { get; set; }

        [MaxLength(DbStrMaxLen.DeckDescriptionLen)]
        public string Description { get; set; }

        [MaxLength(DbStrMaxLen.DeckHeaderImageNameLen)]
        public string HeaderImageName { get; set; }

        //Relationships
        public ICollection<Card> Cards { get; set; }

        public User User { get; set; }
    }
}
