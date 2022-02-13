using System.ComponentModel.DataAnnotations;
using Entities.DbStrLenInfo;

namespace Entities
{
    public class CardImage
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(DbStrMaxLen.CardImageFileNameLen)]
        public string FileName { get; set; }
    }
}
