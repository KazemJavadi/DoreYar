using System.ComponentModel.DataAnnotations;
using Entities.DbStrLenInfo;

namespace DTOs
{
    public class CardImageDto
    {
        public long Id { get; set; }
        [StringLength(DbStrMaxLen.CardImageFileNameLen)]
        public string FileName { get; set; }
    }
}
