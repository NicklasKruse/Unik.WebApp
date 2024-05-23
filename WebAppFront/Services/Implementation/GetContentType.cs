using WebAppFront.Services.Interfaces;

namespace WebAppFront.Services.Services
{

    public class GetContentType : IGetContentType
    {
        /// <summary>
        /// Vi bruger denne metode til at få filtypen af en fil.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }
        /// <summary>
        /// Det er en dictionary, der indeholder filtyper og deres tilsvarende MIME-typer.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetMimeTypes()
        {
            // https://developer.mozilla.org/en-US/docs/Web/HTTP/Basics_of_HTTP/MIME_types type format og liste af MIME-typer
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".csv", "text/csv"}
            };
        }
    }
}
