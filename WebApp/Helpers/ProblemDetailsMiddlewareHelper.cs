namespace WebApp.Helpers
{
    public class ProblemDetailsMiddlewareHelper
    {
        public bool IsProblem(HttpContext httpContext)
        {
            bool IsProblemStatusCode(int? statusCode)
            {
                return statusCode switch
                {
                    >= 600 => false,
                    < 400 => false,
                    null => false,
                    _ => true
                };
            }

            if (httpContext.Request.Path.HasValue)
            {

                var pathParsts = httpContext.Request.Path.Value.Split("/")
                .Select(part => part.Trim().ToLower())
                .Where(part => !string.IsNullOrWhiteSpace(part))
                .ToArray();

                if (pathParsts.Length <= 0 || pathParsts[0] != "api")
                {
                    return false;
                }
            }


            if (!IsProblemStatusCode(httpContext.Response.StatusCode))
            {
                return false;
            }

            if (httpContext.Response.ContentLength.HasValue)
            {
                return false;
            }

            if (string.IsNullOrEmpty(httpContext.Response.ContentType))
            {
                return true;
            }

            return false;
        }
    }
}
