using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTOs
{
    public class CardDto
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public long DeckId { get; set; }
        [Required(ErrorMessage = "پرسش را بنویسید")]
        [StringLength(1000)]
        public string Question { get; set; }
        [Required(ErrorMessage = "پاسخ را بنویسید")]
        [StringLength(int.MaxValue)]
        public string Answer { get; set; }

        public List<CardImageDto> Images { get; set; } = new();

    }
}