using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FrontConnectLibrary.Services;
using FrontConnectLibrary.Interfaces;

public class UploadModel : PageModel
{
    private readonly IFileUploadService _fileUploadService;

    public UploadModel(IFileUploadService fileUploadService)
    {
        _fileUploadService = fileUploadService;
    }

    public async Task<IActionResult> OnPostAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            ModelState.AddModelError("file", "V�lg en fil.");
            return Page();
        }

        var filePath = await _fileUploadService.UploadFileAsync(file);
        return RedirectToPage("/Index", new { filePath });
    }
}