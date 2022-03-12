using Services.DTOs;

namespace WebApp.ViewModels
{
    public class AddNewEditCardPartialViewModel
    {
        public bool IsForEdit { get; set; }
        public InputModel Input { get; set; } = new();

        public class InputModel
        {
            public CardDto Card { get; set; } = new();
            public IFormFile[] Images { get; set; }
        }
    }
}
