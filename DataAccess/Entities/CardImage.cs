using DataAccess.Entities.DbStrLenInfo;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class CardImage
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(DbStrMaxLen.CardImageFileNameLen)]
        public string FileName { get; set; }
    }
}
