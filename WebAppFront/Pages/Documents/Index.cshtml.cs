using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;
using WebAppFront.Services.Interfaces;

namespace WebAppFront.Pages.Documents
{
    /// <summary>
    /// Page til at vise dokumenter
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly IFileUploadService _fileUploadService;

        public IndexModel(IFileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }

        public List<string> Files { get; private set; }
        public void OnGet()
        {
            Files = _fileUploadService.ListFiles().ToList();
        }
    }
}
