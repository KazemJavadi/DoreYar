using DataAccess.Entities.DbStrLenInfo;
using System.ComponentModel.DataAnnotations;

namespace Services.DTOs
{
    public class CardImageDto
    {
        public long Id { get; set; }
        [StringLength(DbStrMaxLen.CardImageFileNameLen)]
        public string FileName { get; set; }
    }
}
