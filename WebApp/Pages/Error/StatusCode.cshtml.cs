using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Error.StatusCode
{
    public class StatusCodeModel : PageModel
    {
        public void OnGet()
        {
            var request = Request;
        }
    }
}
