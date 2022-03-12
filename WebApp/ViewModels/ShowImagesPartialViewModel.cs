using Services.DTOs;

namespace WebApp.ViewModels
{
    public class ShowImagesPartialViewModel
    {
        public bool IsForEdit { get; set; }

        public ICollection<CardImageDto> Images { get; set; }
    }
}
