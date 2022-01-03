using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Helpers;

namespace WebApp.Pages.Error
{
    public class StatusCodeModel : PageModel
    {
        public static string AbsolutePath => RazorPageHelper.GetMyAbsolutePath();

        public int? HttpStatusCode { get; set; }
        public void OnGet(int? statusCode = null)
        {
            HttpStatusCode = statusCode;
        }
    }
}
