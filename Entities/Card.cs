using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.DbStrLenInfo;

namespace Entities
{
    public class Card
    {
        [Required]
        public long Id { get; set; }

        public long DeckId { get; set; }

        private DateTime _regDate;

        public DateTime RegDate => _regDate;

        [Required(ErrorMessage = "You must enter your qeustion")]
        [MaxLength(DbStrMaxLen.CardQuestionLen)]
        public string Question { get; set; }

        [Required(ErrorMessage = "You must enter your answer")]
        [Column(TypeName = "nvarchar(max)")]
        public string Answer { get; set; }

        public long Repetitions { get; set; }
        public decimal EasinessFactor { get; set; }
        public int Interval { get; set; }

        public DateTime? PreviousReviewDate { get; set; }

        public DateTime NextReviewDate { get; set; }

        //Relationships
        public List<CardImage> Images { get; set; } = new();
    }
}