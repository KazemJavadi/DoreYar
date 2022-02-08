using Entities;

namespace WebApp.ViewModels
{
    public class ShowImagesPartialViewModel
    {
        public bool IsForEdit { get; set; }

        public ICollection<CardImage> Images { get; set; }
    }
}
