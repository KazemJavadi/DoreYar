using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using WebApp.Helpers;

namespace WebApp.Pages.CardManagment
{
    public class EditModel : PageModel
    {
        public static string AbsolutePath => RazorPageHelper.GetMyAbsolutePath();

        private readonly CardService _cardService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditModel(CardService cardService, IWebHostEnvironment webHostEnvironment)
        {
            this._cardService = cardService;
            this._webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();
        //public int PageNumber { get; set; }

        public bool? IsEdited { get; set; }


        public void OnGet(long cardId)
        {
            if (ModelState.IsValid)
            {
                Input.Card = _cardService.Get(cardId);
            }
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Input.Images != null && Input.Images.Length > 0)
                {
                    foreach (var image in Input.Images)
                    {


                        FileHelper fileHelper = new FileHelper(_webHostEnvironment);
                        string ImageFileName = fileHelper.SaveCardImage(image);
                        Input.Card.Images.Add(new() { FileName = ImageFileName });
                    }
                }

                _cardService.Edit(Input.Card);

                Input.Card = _cardService.Get(Input.Card.Id);

                IsEdited = true;
            }
            else
                IsEdited = false;
        }


        public class InputModel
        {
            public Card Card { get; set; }
            public IFormFile[] Images { get; set; }
        }
    }
}
