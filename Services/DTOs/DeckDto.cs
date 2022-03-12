using DataAccess.Entities.DbStrLenInfo;
using System.ComponentModel.DataAnnotations;

namespace Services.DTOs
{
    public class DeckDto
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "نام دسته را بنویسید.")]
        [StringLength(DbStrMaxLen.DeckNameLen, ErrorMessage = $"نام دسته ی کوتاه تری برگزینید. شمار حرف های نام دسته باید کمتر از 500 باشد.")]
        public string Name { get; set; }
        [StringLength(DbStrMaxLen.DeckDescriptionLen, ErrorMessage = "توضیح کوتاه تری بنویسید. شمار حرف های توضیحات باید کمتر از 1000 حرف باشد.")]
        public string Description { get; set; }
        public string HeaderImageName { get; set; }

        //Relationships
        public ICollection<CardDto> Cards { get; set; }
    }
}
