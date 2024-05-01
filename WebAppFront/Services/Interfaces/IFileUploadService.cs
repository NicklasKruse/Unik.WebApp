using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppFront.Services.Interfaces
{
    public interface IFileUploadService
    {
        Task<string> UploadFileAsync(IFormFile file);
        IEnumerable<string> ListFiles();
        Task<(Stream FileStream, string ContentType)> GetFileAsync(string fileName);
    }
}
