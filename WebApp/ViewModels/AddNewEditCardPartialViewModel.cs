using Entities;

namespace WebApp.ViewModels
{
    public class AddNewEditCardPartialViewModel
    {
        public bool IsEdit { get; set; }
        public InputModel Input { get; set; } = new ();

        public class InputModel
        {
            public Card Card { get; set; } = new ();
            public IFormFile[] Images { get; set; }
        }
    }
}
