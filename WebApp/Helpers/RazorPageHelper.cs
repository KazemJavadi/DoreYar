using System.Runtime.CompilerServices;

namespace WebApp.Helpers
{
    public static class RazorPageHelper
    {
        public static string GetMyAbsolutePath([CallerFilePath] string callerFileFullPath = null) =>
            ConvertFullPathToRelativeRazorPagePath(callerFileFullPath);

        private static string ConvertFullPathToRelativeRazorPagePath(string fullPath)
        {
            string relativePath = fullPath
                .Remove(0, fullPath.IndexOf("Pages") + 1 + "Pages".Length)
                .Replace('\\', '/')
                .Replace('\\', '/')
                .Insert(0, "/")
                .Replace(".cshtml.cs", string.Empty);

            return relativePath;
        }
    }
}
