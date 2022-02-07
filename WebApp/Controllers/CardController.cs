﻿using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using WebApp.Helpers;

namespace WebApp.Controllers
{
    public class CardController : Controller
    {
        private readonly CardService _cardService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CardController(CardService cardService, IWebHostEnvironment webHostEnvironment)
        {
            this._cardService = cardService;
            this._webHostEnvironment = webHostEnvironment;
        }

        //Add
        [HttpPost]
        public RedirectResult Add(InputModel input)
        {
            if (ModelState.IsValid
                && !string.IsNullOrWhiteSpace(input.Card.Question)
                && !string.IsNullOrWhiteSpace(input.Card.Answer))
            {
                if (input.Image != null)
                {
                    FileHelper fileHelper = new FileHelper(_webHostEnvironment);
                    string ImageFileName = fileHelper.SaveCardImage(input.Image);
                    input.Card.Images.Add(new() { FileName = ImageFileName });
                }

                _cardService.Add(input.Card);
            }

            return RedirectToReferer();
        }


        //Delete
        [HttpGet]
        public IActionResult Delete(int cardId)
        {
            if (ModelState.IsValid && cardId > 0)
            {
                _cardService.Delete(cardId);
            }

            if (cardId <= 0)
                return NotFound();

            return RedirectToReferer();
        }

        private RedirectResult RedirectToReferer() => Redirect(new Uri(Request.Headers["Referer"]).PathAndQuery);

        public class InputModel
        {
            public Card Card { get; set; }
            public IFormFile Image { get; set; }
        }
    }
}
