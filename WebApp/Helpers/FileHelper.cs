using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;

namespace WebApp.Helpers
{
    public class FileHelper
    {
        private IWebHostEnvironment _webHostEnvironment;
        public FileHelper(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public const string DeckHeaderPath = "/upload/deck-header";

        public string SaveDeckHeader(IFormFile formFile)
        {
            string saveFolder = $"{_webHostEnvironment.WebRootPath}{DeckHeaderPath}";
            string uniqueFileName = GetUniqueFileName(formFile.FileName);

            MemoryStream ms = new();
            formFile.CopyTo(ms);

            File.WriteAllBytes($"{saveFolder}/{uniqueFileName}", ms.ToArray());

            return uniqueFileName;
        }

        private string GetUniqueFileName(string fileName)
        {
            string uniqueFileName = 
                $"{GetStandardAlphanumericFileName(Path.GetFileNameWithoutExtension(fileName))}{TimeHelper.GetTimeStampNow()}{random.Next()}{Path.GetExtension(fileName)}";
            return uniqueFileName;
        }

        private string GetStandardAlphanumericFileName(string fileName)
        {
            string alphFileName = GetAlphanumericFileName(fileName);
            if(alphFileName.Length > 20)
                return alphFileName.Substring(0, 20);

            return alphFileName;
        }

        private string GetAlphanumericFileName(string fileName)
        {
            return 
                new string(fileName
                .Where(c=>Char.IsLetter(c) || Char.IsDigit(c)).ToArray()).ToLower();  
        }

        private static Random random = new Random();


        public string GetUniqueFileName(string fileFolder, string realFileName)
        {
            string fileExtension = Path.GetExtension(realFileName);
            string uniqueFileName = TimeHelper.GetTimeStampNow();
            string searchPath = Path.Combine(fileFolder, $"{uniqueFileName}{fileExtension}");
            while (File.Exists(searchPath))
                uniqueFileName += random.Next();

            uniqueFileName += fileExtension;
            return uniqueFileName;
        }

    }
}
