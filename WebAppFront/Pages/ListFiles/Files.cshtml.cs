using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppFront.Services.Interfaces;

public class FilesModel : PageModel
{
    private readonly IFileUploadService _fileUploadService;

    public FilesModel(IFileUploadService fileUploadService)
    {
        _fileUploadService = fileUploadService;
    }

    public List<string> Files { get; private set; }
    /// <summary>
    /// Se filer
    /// </summary>
    public void OnGet()
    {
        Files = _fileUploadService.ListFiles().ToList();
    }
    /// <summary>
    /// Download fil
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public async Task<IActionResult> OnGetDownloadAsync(string fileName)
    {
        var (fileStream, contentType) = await _fileUploadService.GetFileAsync(fileName);
        if (fileStream != null)
        {
            return File(fileStream, contentType, fileName);
        }
        return NotFound();
    }

}
