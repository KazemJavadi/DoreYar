using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Card
    {
        [Required]
        public long Id { get; set; }

        public long DeckId { get; set; }

        [Required(ErrorMessage = "You must enter your qeustion")]
        [MaxLength(1000)]
        [StringLength(1000)]
        public string Question { get; set; }

        [Required(ErrorMessage = "You must enter your answer")]
        [Column(TypeName = "nvarchar(max)")]
        [StringLength(int.MaxValue)]
        public string Answer { get; set; }

        [Required]
        public DateTime PreviousReviewDate { get; set; }

        [Required]
        public DateTime NextReviewDate { get; set; }
    }
}