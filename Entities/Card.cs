using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Card
    {
        public long Id { get; set; }

        public long DeckId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Question { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [StringLength(int.MaxValue)]
        public string Answer { get; set; }

        [Required]
        public DateTime PreviousReviewDate { get; set; }

        [Required]
        public DateTime NextReviewDate { get; set; }
    }
}