using Entities.DbStrLenInfo;
using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class CardImageDto
    {
        public long Id { get; set; }
        [StringLength(DbStrMaxLen.CardImageFileNameLen)]
        public string FileName { get; set; }
    }
}
