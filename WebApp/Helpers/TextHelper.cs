using System.Text.RegularExpressions;

namespace WebApp.Helpers
{
    public class TextHelper
    {
        public string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }
    }
}
