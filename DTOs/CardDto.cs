using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.DbStrLenInfo;

namespace DTOs
{
    public class CardDto
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public long DeckId { get; set; }
        [Required(ErrorMessage = "پرسش را بنویسید")]
        [StringLength(DbStrMaxLen.CardQuestionLen)]
        public string Question { get; set; }
        [Required(ErrorMessage = "پاسخ را بنویسید")]
        [StringLength(DbStrMaxLen.CardAnswerLen)]
        public string Answer { get; set; }

        public List<CardImageDto> Images { get; set; } = new();

    }
}