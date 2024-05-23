using WebAppFront.Services.Interfaces;

namespace WebAppFront.Services.Implementation
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IGetContentType _getContentType;
        public FileUploadService(IGetContentType getContentType)
        {
            _getContentType = getContentType;
        }
        /// <summary>
        /// Upload
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<string> UploadFileAsync(IFormFile file)
        {
            var filePath = Path.Combine("Uploads", file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return filePath;
        }
        /// <summary>
        /// Liste til at se
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ListFiles()
        {
            var directoryPath = Path.Combine("Uploads");
            if (Directory.Exists(directoryPath))
            {
                return Directory.GetFiles(directoryPath).Select(Path.GetFileName); //returner filnavn og kun filnavn for ikke at ødelgge stien.
            }
            return new List<string>();
        }

        /// <summary>
        /// Download
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task<(Stream FileStream, string ContentType)> GetFileAsync(string fileName)
        {
            var filePath = Path.Combine("Uploads", fileName);
            if (File.Exists(filePath))
            {
                var memoryStream = new MemoryStream();
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    await stream.CopyToAsync(memoryStream);
                }
                memoryStream.Position = 0;
                var contentType = _getContentType.GetType(filePath);
                return (memoryStream, contentType);
            }
            return (null, null);
        }

    }
}
