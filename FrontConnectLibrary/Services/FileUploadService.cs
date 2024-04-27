using FrontConnectLibrary.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontConnectLibrary.Services
{
    public class FileUploadService : IFileUploadService
    {
        public async Task<string> UploadFileAsync(IFormFile file)
        {
            var filePath = Path.Combine("Uploads", file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return filePath;
        }
        public IEnumerable<string> ListFiles()
        {
            var directoryPath = Path.Combine("Uploads");
            if (Directory.Exists(directoryPath))
            {
                return Directory.GetFiles(directoryPath);
            }
            return new List<string>();
        }
    }
}
