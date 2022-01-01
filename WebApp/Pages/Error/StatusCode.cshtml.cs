using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Error
{
    public class StatusCodeModel : PageModel
    {
        public int? HttpStatusCode { get; set; }
        public void OnGet(int? statusCode = null)
        {
            HttpStatusCode = statusCode;
        }
    }
}
